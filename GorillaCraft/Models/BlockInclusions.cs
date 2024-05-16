using System;

namespace GorillaCraft.Models
{
    /// <summary>
    /// BlockInclusions is a set of flags passed alongside a block being placed or removed which may alter how the block is handled.
    /// </summary>
    [Flags]
    public enum BlockInclusions
    {
        /// <summary>
        /// The block will not be altered when using this flag by itself.
        /// </summary>
        None = 0,
        /// <summary>
        /// The block will play audio when being placed or removed.
        /// </summary>
        Audio = 1 << 0,
        /// <summary>
        /// The block will emit particles when being removed.
        /// </summary>
        Particles = 1 << 1,
    }
}
