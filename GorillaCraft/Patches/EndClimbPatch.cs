using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Blocks;
using GorillaCraft.Utilities;
using GorillaLibrary.Utilities;
using GorillaLocomotion;
using GorillaLocomotion.Climbing;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

namespace GorillaCraft.Patches;

[HarmonyPatch(typeof(GTPlayer), nameof(GTPlayer.EndClimbing))]
public class EndClimbPatch
{
    public static bool Prefix(GTPlayer __instance, GorillaHandClimber hand, bool startingNewClimb, bool doDontReclimb)
    {
        if (__instance.currentClimbable && __instance.currentClimbable.TryGetComponent(out Ladder ladder))
        {
            if (hand != __instance.currentClimber)
            {
                return true;
            }

            hand.SetCanRelease(canRelease: true);
            if (!startingNewClimb)
            {
                __instance.enablePlayerGravity(useGravity: true);
            }

            Rigidbody component = null;
            if ((bool)__instance.currentClimbable)
            {
                __instance.currentClimbable.TryGetComponent(out component);
                __instance.currentClimbable.isBeingClimbed = false;
            }

            Vector3 force = Vector3.zero;
            if ((bool)__instance.currentClimber)
            {
                __instance.currentClimber.isClimbing = false;
                if (doDontReclimb)
                {
                    __instance.currentClimber.dontReclimbLast = __instance.currentClimbable;
                }
                else
                {
                    __instance.currentClimber.dontReclimbLast = null;
                }

                __instance.currentClimber.queuedToBecomeValidToGrabAgain = true;
                __instance.currentClimber.lastAutoReleasePos = __instance.currentClimber.handRoot.localPosition;
                if (!startingNewClimb && (bool)__instance.currentClimbable)
                {
                    GorillaVelocityTracker interactPointVelocityTracker = __instance.GetInteractPointVelocityTracker(__instance.currentClimber.xrNode == XRNode.LeftHand);
                    if ((bool)component)
                    {
                        __instance.playerRigidBody.linearVelocity = component.linearVelocity;
                    }
                    else if ((bool)__instance.currentSwing)
                    {
                        __instance.playerRigidBody.linearVelocity = __instance.currentSwing.velocityTracker.GetAverageVelocity(worldSpace: true, 0.25f);
                    }
                    else if ((bool)__instance.currentZipline)
                    {
                        __instance.playerRigidBody.linearVelocity = __instance.currentZipline.GetCurrentDirection() * __instance.currentZipline.currentSpeed;
                    }
                    else
                    {
                        __instance.playerRigidBody.linearVelocity = Vector3.zero;
                    }

                    force = __instance.turnParent.transform.rotation * -interactPointVelocityTracker.GetAverageVelocity(worldSpace: false, 0.1f, doMagnitudeCheck: true) * __instance.scale;
                    force = Vector3.ClampMagnitude(force, 5.5f * __instance.scale);
                    __instance.playerRigidBody.AddForce(force, ForceMode.VelocityChange);
                }
            }

            if ((bool)__instance.currentSwing)
            {
                __instance.currentSwing.DetachLocalPlayer();
            }

            if (__instance.currentClimbable.TryGetComponent<PhotonView>(out var _) || __instance.currentClimbable.TryGetComponent<PhotonViewXSceneRef>(out var _) || __instance.currentClimbable.IsPlayerAttached)
            {
                VRRig.DetachLocalPlayerFromPhotonView();
            }

            if (!startingNewClimb && force.magnitude > 2f && (bool)__instance.currentClimbable)
            {
                bool isLeftHand = __instance.currentClimber.xrNode == XRNode.LeftHand;
                var tapSound = ladder.GetComponent<BlockFace>().FaceObject.TapSound;
                MainScript.BlockScript.PlayTapSound(RigUtility.LocalRig, tapSound, isLeftHand);
                NetworkUtility.SurfaceTap(tapSound.SoundId, isLeftHand);
            }

            __instance.currentClimbable = null;
            __instance.currentClimber = null;
            __instance.currentSwing = null;
            __instance.currentZipline = null;
            __instance.isClimbing = false;

            return false;
        }

        return true;
    }
}
