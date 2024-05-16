using UnityEngine;

namespace GorillaCraft.Models
{
    /// <summary>
    /// BlockForm is an enum which describes how the transform of a block will be altered (often using rotation) during placement.
    /// </summary>
    public enum BlockPlacement
    {
        /// <summary>
        /// The block will remain at a static <see cref="Quaternion.identity"/> angle.
        /// </summary>
        Default,
        /// <summary>
        /// The block will have it's angle (yaw) rounded to a multple of a 90 degree angle based on how the player places it.
        /// </summary>
        VerticalRotation_90,
        /// <summary>
        /// The block will have it's angle (yaw) rounded to a multple of a 45 degree angle based on how the player places it.
        /// </summary>
        VerticalRotation_45,
        /// <summary>
        /// The block will have it's angle (roll, pitch, and yaw) rounded to a multiple of a 90 degree angle based on how the player places it.
        /// </summary>
        FullRotation,
        /// <summary>
        /// TBA
        /// </summary>
        Bouncey
    }
}
