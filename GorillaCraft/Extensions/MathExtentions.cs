using System;
using UnityEngine;

namespace GorillaCraft.Extensions
{
    public static class MathExtentions
    {
        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        public static string ToSize(this long value, SizeUnits unit) => (value / (double)Math.Pow(1024, (long)unit)).ToString("0.00");

        public static float RoundToInt(this float value, float multipleOf) => Mathf.RoundToInt(value / multipleOf) * multipleOf;
    }
}
