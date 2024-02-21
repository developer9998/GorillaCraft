namespace GorillaCraft.Behaviours.UI.GamemodeMenu
{
    public class ModeItem : MenuButton
    {
        public ModeMenuHandler menuParent;

        public override void OnPress() => menuParent.ModeItemPress(this);
    }
}
