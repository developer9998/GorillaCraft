using System;

namespace GorillaCraft.Models
{
    public struct BlockFaceInfo
    {
        public string FaceName { get; }
        public Type FaceSurfaceType { get; }
        public bool IsSlippery { get; }

        public BlockFaceInfo(string faceName, Type faceSurfaceType, bool isSlippery = false)
        {
            FaceName = faceName;
            IsSlippery = isSlippery;
            FaceSurfaceType = faceSurfaceType;
        }
    }
}
