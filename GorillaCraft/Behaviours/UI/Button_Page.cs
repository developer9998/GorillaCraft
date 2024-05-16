namespace GorillaCraft.Behaviours.UI
{
    public class Button_Page : MenuButton
    {
        public MenuHandler menuParent;
        public ButtonType buttonType;

        public override void OnButtonActivation(bool select)
        {
            if (select) OnButtonActivation();
        }
        public void OnButtonActivation() => menuParent.PageItemPress(this);

        public enum ButtonType
        {
            Left,
            Right,
            SettingToggle
        }
    }
}
