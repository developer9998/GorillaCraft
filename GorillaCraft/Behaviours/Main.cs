using GorillaCraft.Behaviours.UI.GamemodeMenu;
using GorillaCraft.Behaviours.UI.SelectionMenu;
using UnityEngine;
using Zenject;

namespace GorillaCraft.Behaviours
{
    public class Main : MonoBehaviour, IInitializable
    {
        internal bool isActivated;

        private PlacementHelper PlacementHelper;
        private AssetLoader AssetLoader;

        private MenuHandler MenuHandler;
        private ModeMenuHandler MenuHandler_Mode;

        private bool ModeBindActivated;

        [Inject]
        public void Construct(PlacementHelper placementHelper, AssetLoader assetLoader)
        {
            PlacementHelper = placementHelper;
            AssetLoader = assetLoader;
        }

        public async void Initialize()
        {
            Plugin.Allowed.AddCallback(OnRoomEntered);

            await AssetLoader.LoadAsset<GameObject>("ItemSelector");
            await AssetLoader.LoadAsset<GameObject>("GamemodeSelector");
            await AssetLoader.LoadAsset<Sprite>("gamemode_switcher 1");
            await AssetLoader.LoadAsset<Sprite>("gamemode_switcher 2");

            GameObject itemSelectionMenu = Instantiate(await AssetLoader.LoadAsset<GameObject>("ItemSelector"));
            itemSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);

            MenuHandler = itemSelectionMenu.AddComponent<MenuHandler>();
            MenuHandler._placementHelper = PlacementHelper;

            GameObject modeSelectionMenu = Instantiate(await AssetLoader.LoadAsset<GameObject>("GamemodeSelector"));
            modeSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);
            modeSelectionMenu.SetActive(false); // Hide this, it's not needed right now

            MenuHandler_Mode = modeSelectionMenu.AddComponent<ModeMenuHandler>();
            MenuHandler_Mode._offSprite = await AssetLoader.LoadAsset<Sprite>("gamemode_switcher 1");
            MenuHandler_Mode._onSprite = await AssetLoader.LoadAsset<Sprite>("gamemode_switcher 2");
            MenuHandler_Mode._placementHelper = PlacementHelper;
        }

        public void Update()
        {
            if (!MenuHandler_Mode || !MenuHandler) return;

            if (!isActivated)
            {
                MenuHandler_Mode.gameObject.SetActive(false);
                MenuHandler.gameObject.SetActive(false);
                return;
            }

            bool buttonHeld = ControllerInputPoller.instance.leftControllerPrimaryButton;
            if (buttonHeld && buttonHeld != ModeBindActivated)
            {
                MenuHandler_Mode.gameObject.SetActive(true);
                MenuHandler.gameObject.SetActive(false);
            }
            else if (!buttonHeld && buttonHeld != ModeBindActivated)
            {
                MenuHandler_Mode.gameObject.SetActive(false);
                MenuHandler.gameObject.SetActive(PlacementHelper.Mode != 2);
            }
            ModeBindActivated = buttonHeld;
        }

        private void OnRoomEntered(bool state)
        {
            isActivated = state;
            if (isActivated)
            {
                MenuHandler.gameObject.SetActive(PlacementHelper.Mode != 2);
            }
            else
            {
                MenuHandler_Mode.gameObject.SetActive(false);
                MenuHandler.gameObject.SetActive(false);
            }
        }
    }
}
