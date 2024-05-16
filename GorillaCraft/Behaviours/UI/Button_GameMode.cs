namespace GorillaCraft.Behaviours.UI
{
    public class Button_GameMode : MenuButton
    {
        public GameModeUIHandler menuParent;

        public override void OnButtonActivation(bool select)
        {
            if (select) OnButtonActivation();
        }

        public void OnButtonActivation() => menuParent.ModeItemPress(this);
    }
}
