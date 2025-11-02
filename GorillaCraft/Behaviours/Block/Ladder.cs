using GorillaLocomotion.Climbing;
using UnityEngine;

namespace GorillaCraft.Behaviours.Block
{
    [RequireComponent(typeof(BlockFace)), DisallowMultipleComponent]
    public class Ladder : MonoBehaviour
    {
        private GorillaClimbable Climbable;

        public void Awake()
        {
            Climbable = gameObject.AddComponent<GorillaClimbable>();
            Climbable.maxDistanceSnap = 1f / 2f;
        }

        public void OnDestroy() => Destroy(Climbable);
    }
}
