using GorillaCraft.Behaviours.UI;
using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GorillaCraft.Behaviours
{
    public class MenuHandler : MonoBehaviour
    {
        public static bool IsViewingMenuList;

        public AssetLoader AssetLoader;
        public PlacementHelper Placement;
        public Configuration Config;

        private Transform _uiParent, _modelParent;
        private Vector3 _leftMenuPosition = new(-0.0929f, 0.1055f, 0.0141f), _leftMenuAngle = new(-10.992f, 85.797f, 74.78f);

        private Text _currentItemText;
        private Image _currentItemImage;
        private List<Button_Item> _blockItemList;
        private Dictionary<Button_Item, int> _blockItemCollection;

        private MenuObject _mainMenuObject;
        private List<MenuObject> _menuObjectList;
        private int _currentItemIndex = 0, _currentMenuIndex = 0;

        private Input_Slider _blockSlider;
        private Button_Page _leftButton, _rightButton;

        public void Start()
        {
            transform.localPosition = _leftMenuPosition;
            transform.localEulerAngles = _leftMenuAngle;
            transform.localScale = Vector3.one * 1.146174f;

            _uiParent = transform.Find("UI Parent");
            _modelParent = transform.Find("Menu Parent");

            _leftButton = _uiParent.Find(Constants.PageLeftButton).AddComponent<Button_Page>();
            _leftButton.menuParent = this;
            _leftButton.buttonType = Button_Page.ButtonType.Left;

            _rightButton = _uiParent.Find(Constants.PageRightButton).AddComponent<Button_Page>();
            _rightButton.menuParent = this;
            _rightButton.buttonType = Button_Page.ButtonType.Right;

            _blockSlider = _uiParent.Find(Constants.ItemScrollBar).AddComponent<Input_Slider>();
            _blockSlider.MenuParent = this;
            _blockSlider.Split = 14;
            _blockSlider.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 14
            };
            _blockSlider.OptionData = new ButtonOptionData<float>();

            Button_Page settingsButton = _uiParent.Find("Settings Button").AddComponent<Button_Page>();
            settingsButton.menuParent = this;
            settingsButton.buttonType = Button_Page.ButtonType.SettingToggle;

            #region Item initialization

            _blockItemList = [];
            _blockItemCollection = [];

            Transform blockPageParent = transform.Find(Constants.ItemGridName);
            for (int i = 0; i < blockPageParent.childCount; i++)
            {
                var blockPageObject = blockPageParent.GetChild(i);
                Button_Item blockPageItem = blockPageObject.AddComponent<Button_Item>();

                blockPageItem.menuParent = this;
                _blockItemList.Add(blockPageItem);
                _blockItemCollection.Add(blockPageItem, i);
            }

            _currentItemText = transform.Find(Constants.CurrentItemName).GetComponent<Text>();
            _currentItemImage = transform.Find(Constants.CurrentItemImage).GetComponent<Image>();

            RedrawItems();

            #endregion

            #region Menu object initialization

            _mainMenuObject = new MenuObject()
            {
                Alias = "Default",
                MenuName = "Menu 1",
                PageName = "Main Page"
            };

            _menuObjectList =
            [
                new MenuObject()
                {
                    Alias = "Settings",
                    MenuName = "Menu 2",
                    PageName = "Settings Page"
                },
                new MenuObject()
                {
                    Alias = "Credits",
                    MenuName = "Menu 2",
                    PageName = "Credit Page"
                }
            ];

            RedrawMenus();

            #endregion

            Input_Checkbox darkModeButton = _uiParent.Find("Pages/Settings Page/DarkMode").AddComponent<Input_Checkbox>();
            darkModeButton.MenuParent = this;
            darkModeButton.OptionData = new ButtonOptionData<bool>()
            {
                Name = "Dark Mode",
                Value = Config.DarkMode.Value,
                OnOptionSet = (value) =>
                {
                    Config.DarkMode.Value = value;
                    Shader.SetGlobalInt("_DarkEnabled", value ? 1 : 0);
                }
            };

            Input_Slider slider_BlockResource = _uiParent.Find("Pages/Settings Page/BlockResourceSlider").AddComponent<Input_Slider>();
            slider_BlockResource.MenuParent = this;
            slider_BlockResource.Split = 1;
            slider_BlockResource.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 1f
            };
            slider_BlockResource.SliderContentOverride = new Dictionary<float, string>()
            {
                { 0, "Current" }, { 1, "Legacy" }, { 2, "Faithful"}
            };
            slider_BlockResource.OptionData = new ButtonOptionData<float>()
            {
                Name = "Block Textures",
                Value = 0,
                OnOptionSet = (value) =>
                {
                    Shader.SetGlobalFloat("_MapIndex", value);
                }
            };

            Input_Slider placeButton = _uiParent.Find("Pages/Settings Page/PlaceBreak Volume").AddComponent<Input_Slider>();
            placeButton.MenuParent = this;
            placeButton.Split = 25;
            placeButton.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 100f,
                Prefix = "%"
            };
            placeButton.OptionData = new ButtonOptionData<float>()
            {
                Name = "Place/Break Volume",
                Value = Config.PlaceBreakVolume.Value,
                OnOptionSet = (value) =>
                {
                    Config.PlaceBreakVolume.Value = Mathf.RoundToInt(value);
                }
            };

            Input_Slider stepButton = _uiParent.Find("Pages/Settings Page/Footstep Volume").AddComponent<Input_Slider>();
            stepButton.MenuParent = this;
            stepButton.Split = 25;
            stepButton.SliderData = new ButtonSliderData()
            {
                Least = 0f,
                Greatest = 100f,
                Prefix = "%"
            };
            stepButton.OptionData = new ButtonOptionData<float>()
            {
                Name = "Footstep Volume",
                Value = Config.FootstepVolume.Value,
                OnOptionSet = (value) =>
                {
                    Config.FootstepVolume.Value = Mathf.RoundToInt(value);
                }
            };
        }

        private void RedrawItems()
        {
            try
            {
                int menuWidth = 8, menuHeight = 5, visibilityIndex = -menuWidth * _currentItemIndex;

                for (int i = 0; i < _blockItemList.Count; i++)
                {
                    visibilityIndex++;

                    Button_Item currentItem = _blockItemList[i];

                    int minimumIndex = _currentItemIndex == 0 ? 0 : 1;
                    bool itemEnabled = visibilityIndex <= menuWidth * menuHeight && visibilityIndex >= minimumIndex;

                    currentItem.gameObject.SetActive(itemEnabled);
                }
            }
            catch (Exception exception)
            {
                Logging.Error(exception);
            }
        }

        private void RedrawMenus()
        {
            MenuObject currentMenu = IsViewingMenuList ? _menuObjectList[_currentMenuIndex] : _mainMenuObject;
            (int menuCode, int uiCode) = currentMenu.GetMenuHashCodes(gameObject);
            IEnumerable<MenuObject> menuCollection = new List<MenuObject>(_menuObjectList).Append(_mainMenuObject);

            foreach (MenuObject menu in menuCollection)
            {
                (GameObject menuObject, GameObject uiObject) = menu.GetMenuObject(gameObject);

                menuObject.SetActive(menuObject.GetHashCode() == menuCode);
                uiObject.SetActive(uiObject.GetHashCode() == uiCode);
            }

            _leftButton.gameObject.SetActive(IsViewingMenuList);
            _rightButton.gameObject.SetActive(IsViewingMenuList);
            _blockSlider.gameObject.SetActive(!IsViewingMenuList);
            _currentItemImage.transform.parent.gameObject.SetActive(!IsViewingMenuList);
            _currentItemText.text = IsViewingMenuList ? currentMenu.Alias : Placement.GetBlock().BlockDefinition;
        }

        public void BlockItemPress(Button_Item sender)
        {
            AudioSource source = GetComponent<AudioSource>();

            source.PlayOneShot(source.clip);

            IBlock _newBlock = Placement.SetBlock(_blockItemCollection[sender]);

            _currentItemText.text = _newBlock.BlockDefinition;
            _currentItemImage.sprite = sender.GetComponent<Image>().sprite;
            _currentItemImage.color = sender.GetComponent<Image>().color;
        }

        public async void PageItemPress(Button_Page sender)
        {
            if (sender.buttonType != Button_Page.ButtonType.SettingToggle)
            {
                AudioSource source = GetComponent<AudioSource>();

                source.PlayOneShot(source.clip);

                int increment = sender.buttonType == Button_Page.ButtonType.Right ? 1 : -1;
                _currentMenuIndex = Mathf.Clamp(_currentMenuIndex + increment, 0, _menuObjectList.Count - 1);

                RedrawMenus();
            }
            else
            {

                if (sender.name == "Settings Button")
                {
                    Transform lever = sender.transform.Find("Lever");

                    lever.localScale = new Vector3(lever.localScale.x, lever.localScale.y, -lever.localScale.z);
                    lever.localPosition = new Vector3(lever.localPosition.x, -lever.localPosition.y, lever.localPosition.z);

                    sender.TryGetComponent(out AudioSource source);

                    source.PlayOneShot(IsViewingMenuList ? await AssetLoader.LoadAsset<AudioClip>("Lever2") : await AssetLoader.LoadAsset<AudioClip>("Lever1"));
                }
                else
                {
                    AudioSource source = GetComponent<AudioSource>();

                    source.PlayOneShot(source.clip);
                }

                IsViewingMenuList ^= true;

                RedrawMenus();
            }
        }

        public void SettingButtonPress(Input_Checkbox radio, bool select)
        {
            if (select)
            {
                AudioSource source = GetComponent<AudioSource>();

                source.PlayOneShot(source.clip);
                radio.OptionData.OnOptionSet.Invoke(radio.OptionData.Value);
            }
        }

        public void SettingButtonPress(Input_Slider slider, bool select)
        {
            if (select && slider == _blockSlider)
            {
                _currentItemIndex = Mathf.FloorToInt(slider.SliderData.GetValue(slider.OptionData.Value));

                RedrawItems();
            }
            else if (select && slider != _blockSlider)
            {
                slider.OptionData.OnOptionSet.Invoke(slider.SliderData.GetValue(slider.OptionData.Value));
            }
            else
            {
                AudioSource source = GetComponent<AudioSource>();

                source.PlayOneShot(source.clip);
            }
        }
    }
}
