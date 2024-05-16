using System;
using GorillaCraft.Sounds;

namespace GorillaCraft.Models
{
    /// <summary>
    /// BlockFaceInfo describes information given to the face of a block. 
    /// </summary>
    /// <param name="faceName">The name set as the material for the face.</param>
    /// <param name="faceSurfaceType">The IDataType type of the face. (i.e. <see cref="Surface_Default"/></param>
    public readonly struct BlockFaceInfo(string faceName, Type faceSurfaceType)
    {
        public string FaceName { get; } = faceName;
        public Type FaceSurfaceType { get; } = faceSurfaceType;
    }
}
