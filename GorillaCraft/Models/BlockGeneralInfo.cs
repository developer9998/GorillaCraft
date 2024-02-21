using System;
using UnityEngine;

namespace GorillaCraft.Models
{
    [Serializable]
    public class BlockGeneralInfo
    {
        public string Name { get; set; }
        public Vector3 Position, Euler, Scale;
    }
}
