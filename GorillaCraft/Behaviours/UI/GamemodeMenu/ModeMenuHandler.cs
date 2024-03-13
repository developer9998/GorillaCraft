using GorillaCraft.Extensions;
using GorillaCraft.Tools;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GorillaCraft.Behaviours.UI.GamemodeMenu
{
    public class ModeMenuHandler : MonoBehaviour
    {
        public PlacementHelper _placementHelper;
        public Sprite _offSprite, _onSprite;

        private int _currentModeIndex;
        private List<ModeItem> _modeItemList;
        private Dictionary<ModeItem, int> _modeItemCollection;

        private readonly string[] _modeNames = new string[3] { "Build Mode", "Destroy Mode", "Play Mode" };
        private Text _modeText;

        public Vector3
            LeftPosition = new(-0.0929f, 0.1055f, 0.0141f),
            LeftEuler = new(-10.992f, 85.797f, 74.78f);

        public void Start()
        {
            _modeItemList = new List<ModeItem>();
            _modeItemCollection = new Dictionary<ModeItem, int>();

            transform.localPosition = LeftPosition;
            transform.localEulerAngles = LeftEuler;
            transform.localScale = Vector3.one * 1.146174f;

            Transform modePageParent = transform.Find(Constants.ModeGridName);
            for (int i = 0; i < modePageParent.childCount; i++)
            {
                var modePageObject = modePageParent.GetChild(i);
                ModeItem menuPageItem = modePageObject.gameObject.AddComponent<ModeItem>();

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
                Logging.Log(exception.String(), BepInEx.Logging.LogLevel.Error);
            }
        }

        public void ModeItemPress(ModeItem sender)
        {
            AudioSource source = GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);

            _currentModeIndex = _modeItemCollection[sender];
            _placementHelper.Mode = _currentModeIndex;
            Redraw();
        }
    }
}
