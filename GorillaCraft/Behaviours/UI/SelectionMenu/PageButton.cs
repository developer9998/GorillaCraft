namespace GorillaCraft.Behaviours.UI.SelectionMenu
{
    public class PageButton : MenuButton
    {
        public MenuHandler menuParent;
        public bool isLeftPage;

        public override void OnPress() => menuParent.PageItemPress(this);
    }
}
