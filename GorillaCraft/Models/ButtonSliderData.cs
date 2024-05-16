using UnityEngine;

namespace GorillaCraft.Models
{
    public class ButtonSliderData
    {
        public float Least, Greatest;
        public string Prefix;

        public float GetValue(float rawValue) => Mathf.Lerp(Least, Greatest, rawValue); // lerp automatically clamps the time parameter
    }
}
