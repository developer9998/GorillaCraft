using GorillaCraft.Models;
using System.Collections.Generic;
using UnityEngine.UI;

namespace GorillaCraft.Behaviours.UI
{
    public class Input_Slider : MenuSlider
    {
        public MenuHandler MenuParent;
        public ButtonOptionData<float> OptionData
        {
            get => _optionData;
            set 
            {
                _optionData = value;
                value.OnOptionSet?.Invoke(SliderData.GetValue(value.Value));
            }
        }

        public ButtonSliderData SliderData;
        public Dictionary<float, string> SliderContentOverride = [];

        private Text _optionText;
        private ButtonOptionData<float> _optionData;

        public void Start()
        {
            _optionText = transform.Find("Text")?.GetComponent<Text>() ?? null;
            Value = UnityEngine.Mathf.InverseLerp(SliderData.Least, SliderData.Greatest, OptionData.Value);

            UpdateText();
        }

        public override void OnSliderAdjust(bool select)
        {
            if (select)
            {
                OptionData.Value = Value;
                UpdateText();
            }

            MenuParent.SettingButtonPress(this, select);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void UpdateText()
        {
            if (_optionText)
            {
                _optionText.text = string.Format("{0}: {1}", OptionData.Name, SliderContentOverride.TryGetValue(SliderData.GetValue(OptionData.Value), out string value) ? value : string.Concat(SliderData.GetValue(OptionData.Value), SliderData.Prefix));
            }
        }
    }
}
