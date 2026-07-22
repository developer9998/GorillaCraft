using GorillaCraft.Tools;
using GorillaLibrary.Extensions;
using GorillaLibrary.Models;
using GTMathUtil;
using System;
using UnityEngine;

namespace GorillaCraft.Extensions;

public static class ComponentExtensions
{
    public static bool RigWithinArea(this VRRig rig, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Vector3 head = rig.GetBone(GorillaRigBone.Head).position;
        Vector3 body = rig.GetBone(GorillaRigBone.Body).position;
        Vector3 hand_L = rig.GetBone(GorillaRigBone.LeftHand).position;
        Vector3 hand_R = rig.GetBone(GorillaRigBone.RightHand).position;
        return CheckArea(head, position, rotation, scale) || CheckArea(body, position, rotation, scale) || CheckArea(hand_L, position, rotation, scale) || CheckArea(hand_R, position, rotation, scale);
    }

    private static bool CheckArea(Vector3 point, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Matrix4x4 matrix = Matrix4x4.TRS(position, rotation, scale);
        Vector3 localPoint = matrix.inverse.MultiplyPoint3x4(point);
        return Mathf.Abs(localPoint.x) <= 0.5f && Mathf.Abs(localPoint.y) <= 0.5f && Mathf.Abs(localPoint.z) <= 0.5f;
    }

    public static bool PointWithinFriendCollider(this GorillaFriendCollider friendCollider, Vector3 point)
    {
        try
        {
            bool withLimits = !friendCollider.applyCapsuleYLimits || (point.y >= friendCollider.capsuleColliderYLimits.x && point.y <= friendCollider.capsuleColliderYLimits.y);
            bool withinCollider = (friendCollider.thisBox != null && WithinBounds.PointWithinBoxColliderBounds(point, friendCollider.thisBox)) || (friendCollider.thisBox == null && friendCollider.thisCapsule != null && WithinBounds.PointWithinCapsuleColliderBounds(point, friendCollider.thisCapsule));
            return withLimits && withinCollider;
        }
        catch (Exception ex)
        {
            Logging.Error(ex);
            return false;
        }
    }

    public static bool PointWithinProximity(this CosmeticWardrobeProximityDetector proximityDetector, Vector3 point)
    {
        var collider = proximityDetector.wardrobeNearbyCollider;
        var sqrMagnitude = (point - collider.transform.position).sqrMagnitude;
        return sqrMagnitude <= (collider.radius * collider.radius);
    }
}
