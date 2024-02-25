using System;

namespace GorillaCraft.Models
{
    public struct BlockFaceInfo
    {
        public string FaceName { get; }
        public Type FaceSurfaceType { get; }

        public BlockFaceInfo(string faceName, Type faceSurfaceType)
        {
            FaceName = faceName;
            FaceSurfaceType = faceSurfaceType;
        }
    }
}
