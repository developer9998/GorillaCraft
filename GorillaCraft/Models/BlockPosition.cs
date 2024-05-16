using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GorillaCraft.Models
{
    [Serializable]
    [method: MethodImpl(MethodImplOptions.AggressiveInlining)]
    public struct BlockPosition(float x, float y, float z)
    {
        public float x = x;

        public float y = y;

        public float z = z;

        public static implicit operator BlockPosition(Vector3 v) => new(v.x, v.y, v.z);

        public static implicit operator Vector3(BlockPosition p) => new(p.x, p.y, p.z);
    }
}
