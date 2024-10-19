using BepInEx.Logging;
using GorillaCraft.Extensions;
using GorillaCraft.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GorillaCraft.Behaviours.UI
{
    public class GameModeUIHandler : MonoBehaviour
    {
        public PlacementHelper _placementHelper;
        public Sprite _offSprite, _onSprite;

        private int _currentModeIndex;
        private List<Button_GameMode> _modeItemList;
        private Dictionary<Button_GameMode, int> _modeItemCollection;

        private readonly string[] _modeNames = ["Build Mode", "Pickaxe Mode", "Play Mode"];
        private Text _modeText;

        public Vector3
            LeftPosition = new(-0.0929f, 0.1055f, 0.0141f),
            LeftEuler = new(-10.992f, 85.797f, 74.78f);

        public void Start()
        {
            _modeItemList = [];
            _modeItemCollection = [];

            transform.localPosition = LeftPosition;
            transform.localEulerAngles = LeftEuler;
            transform.localScale = Vector3.one * 1.146174f;

            Transform modePageParent = transform.Find(Constants.ModeGridName);
            for (int i = 0; i < modePageParent.childCount; i++)
            {
                var modePageObject = modePageParent.GetChild(i);
                Button_GameMode menuPageItem = modePageObject.gameObject.AddComponent<Button_GameMode>();

                menuPageItem.menuParent = this;
                _modeItemList.Add(menuPageItem);
                _modeItemCollection.Add(menuPageItem, i);
            }

            _modeText = transform.Find(Constants.CurrentModeName).GetComponent<Text>();
            Redraw();
        }

        private void Redraw()
        {
            try
            {
                for (int i = 0; i < _modeItemList.Count; i++)
                {
                    var currentItem = _modeItemList[i];
                    currentItem.GetComponent<Image>().sprite = _currentModeIndex == i ? _onSprite : _offSprite;
                }
                _modeText.text = _modeNames[_currentModeIndex];
            }
            catch (Exception exception)
            {
                Logging.Error(exception);
            }
        }

        public void ModeItemPress(Button_GameMode sender)
        {
            AudioSource source = GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);

            _currentModeIndex = _modeItemCollection[sender];
            PlacementHelper.InteractMode = _currentModeIndex;
            Redraw();
        }
    }
}
