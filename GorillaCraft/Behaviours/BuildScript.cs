using GorillaCraft.Behaviours.Blocks;
using GorillaCraft.Extensions;
using GorillaCraft.Models;
using GorillaLibrary.Models;
using GorillaLocomotion;
using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GorillaCraft.Behaviours;

public class BuildScript : MonoBehaviour
{
    public BlockObject Block => Blocks[Placement];

    public static int InteractMode = 2;

    private bool _initialized;

    private GTPlayer Player;

    private LayerMask _buildLayerMask, _removeLayerMask;

    public AssetLoaderSync AssetLoader;
    public BlockScript BlockScript;

    public List<BlockObject> Blocks;

    private GameObject _crosshairObject, _placeObject, _destroyObject;
    private LineRenderer _lineRenderer;

    private int Placement;

    private bool IndexActivated;

    private float held_time = 0;

    public void Start()
    {
        if (_initialized) return;
        _initialized = true;

        enabled = false;

        Player = GTPlayer.Instance;

        _buildLayerMask = (int)Player.locomotionEnabledLayers;
        _removeLayerMask = (int)Player.locomotionEnabledLayers;
        _removeLayerMask |= 1 << 17;

        GameObject linePrefab = Instantiate(AssetLoader.LoadAsset<GameObject>("lineRendererExample"));
        linePrefab.transform.localPosition = Vector3.zero;
        _lineRenderer = linePrefab.GetComponent<LineRenderer>();

        _crosshairObject = Instantiate(AssetLoader.LoadAsset<GameObject>("Crosshair"));
        _crosshairObject.transform.localPosition = Vector3.zero;
        _crosshairObject.SetActive(false);

        _placeObject = Instantiate(AssetLoader.LoadAsset<GameObject>("BlockIndicator"));
        _placeObject.transform.localPosition = Vector3.zero;

        _destroyObject = Instantiate(AssetLoader.LoadAsset<GameObject>("BlockRemovalIndicator"));
        _destroyObject.SetActive(false);
        _destroyObject.transform.localPosition = Vector3.zero;

        enabled = true;
    }

    public void LateUpdate()
    {
        if (!MainScript.Instance.InModdedRoom || (MenuHandler.IsViewingMenuList && InteractMode == 0) || InteractMode == 2)
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

        var player_controller = Player.rightHand.controllerTransform;
        var player_follower = Player.rightHand.handFollower;

        _lineRenderer.SetPosition(0, player_controller.position);

        float player_scale = Mathf.Clamp01(GTPlayer.Instance.scale);

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
                        Vector3 eulerAngles = Blocks[Placement].Placement switch
                        {
                            BlockPlacement.VerticalRotation_90 => new Vector3(0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? (Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90) - 90 : 0, 0f),
                            BlockPlacement.VerticalRotation_45 => new Vector3(0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? (Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 45f) * 45f) - 90 : 0, 0f),
                            BlockPlacement.FullRotation => new Vector3(Mathf.RoundToInt(player_controller.eulerAngles.x) != 0 ? Mathf.RoundToInt(player_controller.eulerAngles.x / 90f) * 90 : 0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90 : 0, 0f),
                            _ => Vector3.zero,
                        };

                        Vector3 position = _placeObject.transform.position;

                        if (BlockScript.PlacementAllowed(Blocks[Placement], position, hit))
                        {
                            BlockScript.PlaceBlock(BlockPlaceType.Local, Blocks[Placement], Guid.NewGuid(), position, Blocks[Placement].Form != BlockForm.Ladder ? eulerAngles : hit.collider.transform.eulerAngles, Mathf.Clamp01(player_scale), PhotonNetwork.LocalPlayer, out Block createdBlock, BlockInclusions.Audio);

                            if (createdBlock && Blocks[Placement].Form == BlockForm.Ladder)
                            {
                                var face = hit.collider.GetComponent<BlockFace>();
                                face.ChildBlocks.Add(createdBlock);
                                createdBlock.ParentalBlock = face.Root;
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
                            BlockScript.RemoveBlock(block_surface.Root, PhotonNetwork.LocalPlayer, BlockInclusions.Audio | BlockInclusions.Particles);
                        }
                    }
                    return;
                }

                // trigger is held, but is on cooldown

                held_time += Time.deltaTime;

                if (held_time > 0.2f)
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

    public BlockObject SelectBlock(int blockIndex)
    {
        Placement = Blocks.Count - 1 < blockIndex ? 0 : blockIndex;
        return Blocks[Placement];
    }
}
