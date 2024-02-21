namespace GorillaCraft.Behaviours.UI.SelectionMenu
{
    public class BlockItem : MenuButton
    {
        public MenuHandler menuParent;
        public override void OnPress() => menuParent.BlockItemPress(this);
    }
}
