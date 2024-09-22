using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Block;
using GorillaCraft.Utilities;
using GorillaLocomotion;
using GorillaLocomotion.Climbing;
using HarmonyLib;
using UnityEngine;
using UnityEngine.XR;

namespace GorillaCraft.Patches
{
    [HarmonyPatch(typeof(Player), "EndClimbing")]
    public class EndClimbPatch
    {
        public static bool Prefix(Player __instance, GorillaHandClimber hand, bool startingNewClimb, bool doDontReclimb, ref GorillaHandClimber ___currentClimber, ref GorillaClimbable ___currentClimbable)
        {
            if (___currentClimbable && ___currentClimbable.TryGetComponent(out Ladder ladder))
            {
                if (hand != ___currentClimber) return false;

                if (!startingNewClimb) __instance.bodyCollider.attachedRigidbody.useGravity = true;
                ___currentClimbable.isBeingClimbed = false;

                if (___currentClimber)
                {
                    ___currentClimber.isClimbing = false;
                    ___currentClimber.dontReclimbLast = doDontReclimb ? ___currentClimbable : null;

                    ___currentClimber.queuedToBecomeValidToGrabAgain = true;
                    ___currentClimber.lastAutoReleasePos = ___currentClimber.handRoot.localPosition;

                    GorillaVelocityTracker gorillaVelocityTracker = ___currentClimber.xrNode != XRNode.LeftHand ? __instance.rightInteractPointVelocityTracker : __instance.leftInteractPointVelocityTracker;
                    if (!startingNewClimb)
                    {
                        __instance.bodyCollider.attachedRigidbody.velocity = __instance.bodyVelocityTracker.GetAverageVelocity(true) * 0.1f;

                        Vector3 force = __instance.turnParent.transform.rotation * -(gorillaVelocityTracker.GetAverageVelocity(false, 0.1f, true) * 0.33f) * __instance.scale;
                        force = Vector3.ClampMagnitude(force, 5.5f * __instance.scale);

                        __instance.bodyCollider.attachedRigidbody.AddForce(force, ForceMode.VelocityChange);
                    }

                    if (gorillaVelocityTracker.GetAverageVelocity(false, 0.2f, true).sqrMagnitude > 1.3f)
                    {
                        Player.Instance.GetComponent<BlockHandler>().PlayTapSound(GorillaTagger.Instance.offlineVRRig, ladder.GetComponent<BlockFace>().SurfaceType, ___currentClimber.xrNode == XRNode.LeftHand);
                        // NetworkUtils.SurfaceTap(ladder.GetComponent<BlockFace>().SurfaceType.Name, ___currentClimber.xrNode == XRNode.LeftHand);
                    }
                }

                ___currentClimbable = null;
                ___currentClimber = null;
                __instance.isClimbing = false;
                return false;
            }
            return true;
        }
    }
}
