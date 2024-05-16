namespace GorillaCraft.Behaviours.UI
{
    public class Button_Item : MenuButton
    {
        public MenuHandler menuParent;

        public override void OnButtonActivation(bool select)
        {
            if (select) OnButtonActivation();
        }
        public void OnButtonActivation() => menuParent.BlockItemPress(this);
    }
}
