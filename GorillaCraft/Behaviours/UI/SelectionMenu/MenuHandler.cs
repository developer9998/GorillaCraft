using GorillaCraft.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GorillaCraft.Behaviours.UI.SelectionMenu
{
    public class MenuHandler : MonoBehaviour
    {
        public PlacementHelper _placementHelper;

        private Text _currentItemText;
        private Image _currentItemImage;
        private List<BlockItem> _blockItemList;
        private Dictionary<BlockItem, int> _blockItemCollection;

        private const int
            _minimumPage = 0,
            _maximumPage = 4;
        private int _currentPage = 0;

        public Vector3
            LeftPosition = new(-0.0929f, 0.1055f, 0.0141f),
            LeftEuler = new(-10.992f, 85.797f, 74.78f);

        public void Start()
        {
            _blockItemList = new List<BlockItem>();
            _blockItemCollection = new Dictionary<BlockItem, int>();

            transform.localPosition = LeftPosition;
            transform.localEulerAngles = LeftEuler;
            transform.localScale = Vector3.one * 1.146174f;

            Transform blockPageParent = transform.Find(Constants.PageGridName);
            for (int i = 0; i < blockPageParent.childCount; i++)
            {
                var blockPageObject = blockPageParent.GetChild(i);
                BlockItem blockPageItem = blockPageObject.gameObject.AddComponent<BlockItem>();

                blockPageItem.menuParent = this;
                _blockItemList.Add(blockPageItem);
                _blockItemCollection.Add(blockPageItem, i);
            }

            _currentItemText = transform.Find(Constants.CurrentItemName).GetComponent<Text>();
            _currentItemImage = transform.Find(Constants.CurrentItemImage).GetComponent<Image>();

            transform.Find("UI Parent/Next Page").gameObject.AddComponent<PageButton>().menuParent = this;
            var previousPageButton = transform.Find("UI Parent/Previous Page").gameObject.AddComponent<PageButton>();
            previousPageButton.menuParent = this;
            previousPageButton.isLeftPage = true;

            Redraw();
        }

        private void Redraw()
        {
            int currentPageCount = 10;
            int currentPage = 0;
            for (int i = 0; i < _blockItemList.Count; i++)
            {
                currentPage = currentPageCount - 1 == 0 ? currentPage + 1 : currentPage;
                currentPageCount = currentPageCount == 1 ? 9 : currentPageCount - 1;

                bool pageEnabled = (_currentPage == currentPage || _currentPage + 5 > currentPage) && currentPage + 1 > _currentPage;

                var currentItem = _blockItemList[i];
                currentItem.gameObject.SetActive(pageEnabled);
            }
        }

        public void BlockItemPress(BlockItem sender)
        {
            AudioSource source = GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);

            IBlock _newBlock = _placementHelper.SetBlock(_blockItemCollection[sender]);
            _currentItemText.text = _newBlock.BlockDefinition;

            _currentItemImage.sprite = sender.GetComponent<Image>().sprite;
            _currentItemImage.color = sender.GetComponent<Image>().color;
        }

        public void PageItemPress(PageButton sender)
        {
            AudioSource source = GetComponent<AudioSource>();
            source.PlayOneShot(source.clip);

            int increment = sender.isLeftPage ? -1 : 1;
            _currentPage = Mathf.Clamp(_currentPage + increment, _minimumPage, _maximumPage);
            Redraw();
        }
    }
}
