using GorillaCraft.Behaviours.Block;
using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaLocomotion;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GorillaCraft.Behaviours
{
    public class PlacementHelper : MonoBehaviour
    {
        private bool Initialized;

        private Player Player;

        private LayerMask BuildMask, RemoveMask;

        private Main Main;
        private AssetLoader AssetLoader;
        private BlockHandler BlockHandler;

        private List<IBlock> BlockList;

        private GameObject Crosshair, PlaceIndicator, DestroyIndicator;
        private LineRenderer LineRenderer;

        internal int Mode, Placement;

        private bool IndexActivated;

        [Inject]
        public async void Construct(Main main, AssetLoader assetLoader, BlockHandler blockHandler, List<IBlock> blockList)
        {
            if (Initialized) return;
            Initialized = true;

            Player = GetComponent<Player>();

            BuildMask = (int)Player.locomotionEnabledLayers;
            RemoveMask = (int)Player.locomotionEnabledLayers;
            RemoveMask |= 1 << 19;

            Main = main;
            AssetLoader = assetLoader;
            BlockHandler = blockHandler;

            BlockList = blockList;

            GameObject linePrefab = Instantiate(await AssetLoader.LoadAsset<GameObject>("lineRendererExample"));
            linePrefab.transform.localPosition = Vector3.zero;
            LineRenderer = linePrefab.GetComponent<LineRenderer>();

            Crosshair = Instantiate(await AssetLoader.LoadAsset<GameObject>("Crosshair"));
            Crosshair.transform.localPosition = Vector3.zero;
            Crosshair.SetActive(false);

            PlaceIndicator = Instantiate(await AssetLoader.LoadAsset<GameObject>("BlockIndicator"));
            PlaceIndicator.transform.localPosition = Vector3.zero;

            DestroyIndicator = Instantiate(await AssetLoader.LoadAsset<GameObject>("BlockRemovalIndicator"));
            DestroyIndicator.SetActive(false);
            DestroyIndicator.transform.localPosition = Vector3.zero;
        }

        public IBlock SetBlock(int blockIndex)
        {
            Placement = BlockList.Count - 1 < blockIndex ? 0 : blockIndex;
            return BlockList[Placement];
        }

        public void Update()
        {
            if (Player == null || PlaceIndicator == null || LineRenderer == null) return;

            if (Mode == 2 || !Main.isActivated)
            {
                if (PlaceIndicator.activeSelf || DestroyIndicator.activeSelf || Crosshair.activeSelf)
                {
                    PlaceIndicator.SetActive(false);
                    DestroyIndicator.SetActive(false);
                    Crosshair.SetActive(false);
                }
                LineRenderer.enabled = false;
                return;
            }

            LineRenderer.SetPosition(0, Player.rightControllerTransform.position);

            // Adjust the scale for the preview objects based on the player's scale
            PlaceIndicator.transform.localScale = Vector3.one * Mathf.Clamp01(Player.scale);
            Crosshair.transform.localScale = Vector3.one * 0.04458661f * Mathf.Clamp01(Player.scale);
            LineRenderer.startWidth = 0.007f * Mathf.Clamp01(Player.scale);
            LineRenderer.endWidth = 0.007f * Mathf.Clamp01(Player.scale);

            if (Physics.Raycast(Player.rightHandFollower.position, -Player.rightControllerTransform.up, out RaycastHit hit, 24 * Mathf.Clamp01(Player.scale), Mode == 0 ? BuildMask : RemoveMask, QueryTriggerInteraction.UseGlobal))
            {
                LineRenderer.enabled = true;
                if (!Crosshair.activeSelf) Crosshair.SetActive(true);

                if (!PlaceIndicator.activeSelf && Mode == 0)
                {
                    PlaceIndicator.SetActive(true);
                    DestroyIndicator.SetActive(false);
                }

                bool blockExists = hit.transform.GetComponent<BlockFace>() != null;
                if (Mode == 1 && blockExists && !DestroyIndicator.activeSelf)
                {
                    PlaceIndicator.SetActive(false);
                    DestroyIndicator.SetActive(true);
                    DestroyIndicator.transform.localScale = hit.transform.GetComponent<BlockFace>().Block.transform.localScale + (Vector3.one * (0.02f * Mathf.Clamp01(Player.scale)));
                }
                else if (Mode == 1 && !blockExists)
                {
                    PlaceIndicator.SetActive(false);
                    DestroyIndicator.SetActive(false);
                }

                Vector3 adjustedPosition = new(hit.point.x.RoundToInt(Player.scale), hit.point.y.RoundToInt(Player.scale), hit.point.z.RoundToInt(Player.scale));
                adjustedPosition = Mode == 1 && hit.transform.GetComponent<BlockFace>() != null ? hit.transform.GetComponent<BlockFace>().Block.transform.position : adjustedPosition;

                PlaceIndicator.transform.position = adjustedPosition;
                DestroyIndicator.transform.position = adjustedPosition;

                LineRenderer.SetPosition(1, hit.point);
                Crosshair.transform.position = hit.point;
                Crosshair.transform.up = hit.normal;

                bool triggerPressed = ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f;
                if (triggerPressed && triggerPressed != IndexActivated)
                {
                    if (Mode == 0)
                    {
                        Vector3 eulerAngles = BlockList[Placement].BlockPlacement switch
                        {
                            BlockPlacement.VerticalRotation_90 => new Vector3(0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? (Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90) - 90 : 0, 0f),
                            BlockPlacement.VerticalRotation_45 => new Vector3(0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? (Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 45f) * 45f) - 90 : 0, 0f),
                            BlockPlacement.FullRotation => new Vector3(Mathf.RoundToInt(Player.rightControllerTransform.eulerAngles.x) != 0 ? Mathf.RoundToInt(Player.rightControllerTransform.eulerAngles.x / 90f) * 90 : 0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90 : 0, 0f),
                            _ => Vector3.zero,
                        };

                        BlockHandler.PlaceBlock(BlockPlaceType.Local, BlockList[Placement].GetType().Name, PlaceIndicator.transform.position, eulerAngles, Vector3.one * Mathf.Clamp01(Player.scale), PhotonNetwork.LocalPlayer);
                        IndexActivated = triggerPressed;
                        return;
                    }

                    if (hit.transform.TryGetComponent(out BlockFace face) && face.Block.Owner.IsLocal)
                    {
                        BlockHandler.RemoveBlock(face.Block, PhotonNetwork.LocalPlayer);
                    }
                }
                IndexActivated = triggerPressed;
                return;
            }

            PlaceIndicator.SetActive(false);
            DestroyIndicator.SetActive(false);
            Crosshair.SetActive(false);
            LineRenderer.enabled = false;
        }
    }
}
