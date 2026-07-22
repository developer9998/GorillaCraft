using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Blocks;
using GorillaCraft.Utilities;
using GorillaLibrary.Extensions;
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

            if (__instance.currentClimbable.IsObjectExistent())
            {
                __instance.currentClimbable.isBeingClimbed = false;
            }

            if (__instance.currentClimber.IsObjectExistent())
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
                if (!startingNewClimb && __instance.currentClimbable.IsObjectExistent())
                {
                    GorillaVelocityTracker interactPointVelocityTracker = __instance.GetInteractPointVelocityTracker(__instance.currentClimber.xrNode == XRNode.LeftHand);
                    __instance.playerRigidBody.linearVelocity = Vector3.zero;

                    Vector3 force = __instance.turnParent.transform.rotation * -(interactPointVelocityTracker.GetAverageVelocity(false, 0.1f, true) * 0.33f) * __instance.scale;
                    force = Vector3.ClampMagnitude(force, 5.5f * __instance.scale);
                    __instance.bodyCollider.attachedRigidbody.AddForce(force, ForceMode.VelocityChange);

                    if (interactPointVelocityTracker.GetAverageVelocity(false, 0.2f, true).sqrMagnitude > 1.3f)
                    {
                        bool isLeftHand = __instance.currentClimber.xrNode == XRNode.LeftHand;
                        var tapSound = ladder.GetComponent<BlockFace>().FaceObject.TapSound;
                        MainScript.BlockScript.PlayTapSound(RigUtility.LocalRig, tapSound, isLeftHand);
                        NetworkUtility.SurfaceTap(tapSound.SoundId, isLeftHand);
                    }
                }
            }

            if (__instance.currentSwing.IsObjectExistent())
            {
                __instance.currentSwing.DetachLocalPlayer();
            }

            if (__instance.currentClimbable.GetComponent<PhotonView>().IsObjectExistent() || __instance.currentClimbable.GetComponent<PhotonViewXSceneRef>().IsObjectExistent() || __instance.currentClimbable.IsPlayerAttached)
            {
                VRRig.DetachLocalPlayerFromPhotonView();
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
