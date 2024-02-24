using UnityEngine;

namespace GorillaCraft.Extensions
{
    public static class MathExtentions
    {
        public static float RoundToInt(this float value, float multipleOf) => Mathf.RoundToInt(value / multipleOf) * multipleOf;
    }
}
