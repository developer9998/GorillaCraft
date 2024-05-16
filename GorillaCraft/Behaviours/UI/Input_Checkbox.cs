using GorillaCraft.Models;
using UnityEngine.UI;

namespace GorillaCraft.Behaviours.UI
{
    public class Input_Checkbox : MenuButton
    {
        public MenuHandler MenuParent;
        public ButtonOptionData<bool> OptionData
        {
            get => _optionData;
            set
            {
                _optionData = value;
                value.OnOptionSet?.Invoke(value.Value);
            }
        }

        private Text _optionText;
        private ButtonOptionData<bool> _optionData;

        public void Start()
        {
            _optionText = transform.Find("Text").GetComponent<Text>();

            UpdateText();
        }

        public override void OnButtonActivation(bool select)
        {
            if (select)
            {
                OptionData.Value ^= true;
                UpdateText();
            }

            MenuParent.SettingButtonPress(this, select);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        private void UpdateText() => _optionText.text = string.Format("{0}: {1}", OptionData.Name, OptionData.Value ? "ON" : "OFF");
    }
}
