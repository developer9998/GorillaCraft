using GorillaCraft.Behaviours.Block;
using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaLocomotion;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GorillaCraft.Behaviours
{
    public class PlacementHelper : MonoBehaviour
    {
        public static int InteractMode;

        private bool _initialized;

        private Player Player;

        private LayerMask _buildLayerMask, _removeLayerMask;

        private AssetLoader _assetLoader;
        private BlockHandler _blockHandler;

        private List<IBlock> _blockList;

        private GameObject _crosshairObject, _placeObject, _destroyObject;
        private LineRenderer _lineRenderer;

        private int Placement;

        private bool IndexActivated;

        private float held_time = 0;

        public void Awake()
        {
            enabled = false;
        }

        [Inject]
        public async void Construct(AssetLoader assetLoader, BlockHandler blockHandler, List<IBlock> blockList)
        {
            if (_initialized) return;
            _initialized = true;

            Player = GetComponent<Player>();

            _buildLayerMask = (int)Player.locomotionEnabledLayers;
            _removeLayerMask = (int)Player.locomotionEnabledLayers;
            _removeLayerMask |= 1 << 17;

            _assetLoader = assetLoader;
            _blockHandler = blockHandler;

            _blockList = blockList;

            GameObject linePrefab = Instantiate(await _assetLoader.LoadAsset<GameObject>("lineRendererExample"));
            linePrefab.transform.localPosition = Vector3.zero;
            _lineRenderer = linePrefab.GetComponent<LineRenderer>();

            _crosshairObject = Instantiate(await _assetLoader.LoadAsset<GameObject>("Crosshair"));
            _crosshairObject.transform.localPosition = Vector3.zero;
            _crosshairObject.SetActive(false);

            _placeObject = Instantiate(await _assetLoader.LoadAsset<GameObject>("BlockIndicator"));
            _placeObject.transform.localPosition = Vector3.zero;

            _destroyObject = Instantiate(await _assetLoader.LoadAsset<GameObject>("BlockRemovalIndicator"));
            _destroyObject.SetActive(false);
            _destroyObject.transform.localPosition = Vector3.zero;

            enabled = true;
        }

        public IBlock Block
        {
            get => _blockList[Placement];
        }

        public IBlock SetBlock(int blockIndex)
        {
            Placement = _blockList.Count - 1 < blockIndex ? 0 : blockIndex;
            return _blockList[Placement];
        }

        public void LateUpdate()
        {
            //if (!Player || !_placeObject || !_destroyObject || !_lineRenderer) return;

            if (!Main.InModdedRoom || (MenuHandler.IsViewingMenuList && InteractMode == 0) || InteractMode == 2)
            {
                held_time = 0;
                if (_placeObject.activeSelf || _destroyObject.activeSelf || _crosshairObject.activeSelf)
                {
                    _placeObject.SetActive(false);
                    _destroyObject.SetActive(false);
                    _crosshairObject.SetActive(false);
                }
                _lineRenderer.enabled = false;
                return;
            }

            var player_controller = Player.rightControllerTransform;
            var player_follower = Player.rightHandFollower;

            _lineRenderer.SetPosition(0, player_controller.position);

            float player_scale = Player.NativeScale * Player.ScaleMultiplier;

            // Adjust the scale for the preview objects based on the player's scale
            _placeObject.transform.localScale = Vector3.one * Mathf.Clamp01(player_scale);
            _crosshairObject.transform.localScale = Vector3.one * 0.04458661f * Mathf.Clamp01(player_scale);
            _lineRenderer.startWidth = 0.007f * Mathf.Clamp01(player_scale);
            _lineRenderer.endWidth = 0.007f * Mathf.Clamp01(player_scale);

            if (Physics.Raycast(player_follower.position, -player_controller.up, out RaycastHit hit, 25 * Mathf.Clamp01(player_scale), InteractMode == 0 ? _buildLayerMask : _removeLayerMask, QueryTriggerInteraction.UseGlobal))
            {
                _lineRenderer.enabled = true;
                if (!_crosshairObject.activeSelf) _crosshairObject.SetActive(true);

                if (!_placeObject.activeSelf && InteractMode == 0)
                {
                    _placeObject.SetActive(true);
                    _destroyObject.SetActive(false);
                }

                var block_surface = hit.transform.GetComponentInChildren<BlockFace>();

                if (InteractMode == 1 && (bool)block_surface && !_destroyObject.activeSelf)
                {
                    _placeObject.SetActive(false);
                    _destroyObject.SetActive(true);
                    _destroyObject.transform.localScale = block_surface.Root.transform.localScale + (Vector3.one * (0.02f * Mathf.Clamp01(player_scale)));
                }
                else if (InteractMode == 1 && !(bool)block_surface)
                {
                    _placeObject.SetActive(false);
                    _destroyObject.SetActive(false);
                }

                Vector3 block_target_position = new(hit.point.x.RoundToInt(player_scale), hit.point.y.RoundToInt(player_scale), hit.point.z.RoundToInt(player_scale));
                block_target_position = InteractMode == 1 && (bool)block_surface ? block_surface.Root.transform.position : block_target_position;

                _placeObject.transform.position = block_target_position;
                _destroyObject.transform.position = block_target_position;

                _lineRenderer.SetPosition(1, hit.point);
                _crosshairObject.transform.position = hit.point;
                _crosshairObject.transform.up = hit.normal;

                bool triggerPressed = ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f;
                if (triggerPressed)
                {
                    if (!IndexActivated)
                    {
                        IndexActivated = true;
                        held_time = 0f;

                        if (InteractMode == 0)
                        {
                            Vector3 eulerAngles = _blockList[Placement].Placement switch
                            {
                                BlockPlacement.VerticalRotation_90 => new Vector3(0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? (Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90) - 90 : 0, 0f),
                                BlockPlacement.VerticalRotation_45 => new Vector3(0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? (Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 45f) * 45f) - 90 : 0, 0f),
                                BlockPlacement.FullRotation => new Vector3(Mathf.RoundToInt(player_controller.eulerAngles.x) != 0 ? Mathf.RoundToInt(player_controller.eulerAngles.x / 90f) * 90 : 0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90 : 0, 0f),
                                _ => Vector3.zero,
                            };

                            //IndexActivated = triggerPressed;
                            if (_blockHandler.PlacementAllowed(_blockList[Placement].GetType().FullName, hit))
                            {
                                _blockHandler.PlaceBlock(BlockPlaceType.Local, _blockList[Placement].GetType().Name, _placeObject.transform.position, _blockList[Placement].Form != BlockForm.Ladder ? eulerAngles : hit.collider.transform.eulerAngles, Vector3.one * Mathf.Clamp01(player_scale), PhotonNetwork.LocalPlayer, out BlockObject parent, BlockInclusions.Audio);
                                if (parent && _blockList[Placement].Form == BlockForm.Ladder)
                                {
                                    parent.ParentalBlocks.Add(hit.collider.GetComponent<BlockFace>().Root);
                                    hit.collider.GetComponent<BlockFace>().Root.ChildrenBlocks.Add(parent);
                                }
                            }

                            return;
                        }

                        if ((bool)block_surface)
                        {
                            bool networkBreakFactor = block_surface.Root.Owner.IsLocal;
                            // bool networkBreakFactor = true;
                            if (networkBreakFactor)
                            {
                                _blockHandler.RemoveBlock(block_surface.Root, PhotonNetwork.LocalPlayer);
                            }
                        }
                        return;
                    }

                    // trigger is held, but is on cooldown

                    held_time += Time.deltaTime;

                    if (held_time > 0.25f)
                    {
                        held_time = 0f;
                        IndexActivated = false;
                    }

                    return;
                }

                // trigger isn't held

                IndexActivated = false;
                held_time = 0f;

                return;
            }

            _placeObject.SetActive(false);
            _destroyObject.SetActive(false);
            _crosshairObject.SetActive(false);
            _lineRenderer.enabled = false;
        }
    }
}
