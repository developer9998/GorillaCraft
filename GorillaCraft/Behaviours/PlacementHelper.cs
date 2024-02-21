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

        private AssetLoader AssetLoader;
        private BlockHandler BlockHandler;
        private List<IBlock> BlockList;

        private GameObject PlaceIndicator, DestroyIndicator;
        private LineRenderer LineRenderer;

        private int iMode = 0, iPlacement = 0;

        private bool IndexActivated;

        [Inject]
        public async void Construct(AssetLoader assetLoader, BlockHandler blockHandler, List<IBlock> blockList)
        {
            if (Initialized) return;
            Initialized = true;

            Player = GetComponent<Player>();
            AssetLoader = assetLoader;

            BlockHandler = blockHandler;
            BlockList = blockList;

            GameObject linePrefab = Instantiate(await AssetLoader.LoadAsset<GameObject>("lineRendererExample"));
            linePrefab.transform.localPosition = Vector3.zero;
            LineRenderer = linePrefab.GetComponent<LineRenderer>();

            PlaceIndicator = Instantiate(await AssetLoader.LoadAsset<GameObject>("BlockIndicator"));
            PlaceIndicator.transform.localPosition = Vector3.zero;

            DestroyIndicator = Instantiate(await AssetLoader.LoadAsset<GameObject>("BlockIndicatorRed"));
            DestroyIndicator.SetActive(false);
            DestroyIndicator.transform.localPosition = Vector3.zero;
        }

        public int GetBuildMode() => iMode;

        public void SetBuildMode(int modeIndex)
        {
            iMode = modeIndex;
            Update();
        }

        public IBlock SetBlock(int blockIndex)
        {
            iPlacement = BlockList.Count - 1 < blockIndex ? 0 : blockIndex;
            return BlockList[iPlacement];
        }

        public void Update()
        {
            if (Player == null || PlaceIndicator == null || LineRenderer == null) return;

            if (iMode == 2 || !Plugin.InRoom)
            {
                if (PlaceIndicator.activeSelf || DestroyIndicator.activeSelf)
                {
                    PlaceIndicator.SetActive(false);
                    DestroyIndicator.SetActive(false);
                }
                LineRenderer.enabled = false;
                return;
            }


            LineRenderer.SetPosition(0, Player.rightControllerTransform.position);
            LineRenderer.material.color = iMode == 0 ? new Color(0, 0.8245816f, 1, 0.2f) : new Color(1, 0, 0, 0.2f);

            // Adjust the scale for the preview objects based on the player's scale
            PlaceIndicator.transform.localScale = Vector3.one * Player.scale;
            DestroyIndicator.transform.localScale = Vector3.one * Player.scale;
            LineRenderer.startWidth = 0.045f * Player.scale;
            LineRenderer.endWidth = 0.045f * Player.scale;

            if (Physics.Raycast(Player.rightHandFollower.position, -Player.rightControllerTransform.up, out RaycastHit hit, 25 * Player.scale, Player.Instance.locomotionEnabledLayers, QueryTriggerInteraction.Ignore))
            {
                LineRenderer.enabled = true;
                if (!PlaceIndicator.activeSelf && iMode == 0)
                {
                    PlaceIndicator.SetActive(true);
                    DestroyIndicator.SetActive(false);
                }
                if (!DestroyIndicator.activeSelf && iMode == 1)
                {
                    PlaceIndicator.SetActive(false);
                    DestroyIndicator.SetActive(true);
                }

                Vector3 adjustedPosition = new(hit.point.x.RoundToInt(Player.scale), hit.point.y.RoundToInt(Player.scale), hit.point.z.RoundToInt(Player.scale));
                adjustedPosition = iMode == 1 && hit.transform.GetComponent<BlockFace>() != null ? hit.transform.GetComponent<BlockFace>().baseBlock.transform.position : adjustedPosition;

                PlaceIndicator.transform.position = adjustedPosition;
                DestroyIndicator.transform.position = adjustedPosition;
                DestroyIndicator.transform.localScale = hit.transform.GetComponent<BlockFace>() != null ? hit.transform.GetComponent<BlockFace>().baseBlock.transform.localScale + Vector3.one * 0.025f : DestroyIndicator.transform.localScale;

                LineRenderer.SetPosition(1, PlaceIndicator.transform.position);

                bool triggerPressed = ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f;
                if (triggerPressed && triggerPressed != IndexActivated)
                {
                    if (iMode == 0)
                    {
                        Vector3 eulerAngles = BlockList[iPlacement].BlockType switch
                        {
                            BlockBehaviourType.LimitedRotation => new Vector3(0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90 : 0, 0f),
                            BlockBehaviourType.FullRotation => new Vector3(Mathf.RoundToInt(Player.rightControllerTransform.eulerAngles.x) != 0 ? Mathf.RoundToInt(Player.rightControllerTransform.eulerAngles.x / 90f) * 90 : 0, Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y) != 0 ? Mathf.RoundToInt(Player.bodyCollider.transform.eulerAngles.y / 90f) * 90 : 0, 0f),
                            _ => Vector3.zero,
                        };

                        BlockHandler.PlaceBlock(BlockPlaceType.Local, BlockList[iPlacement].GetType().Name, PlaceIndicator.transform.position, eulerAngles, Vector3.one * Player.scale, PhotonNetwork.LocalPlayer);
                        IndexActivated = triggerPressed;
                        return;
                    }

                    if (hit.transform.TryGetComponent(out BlockFace face) && face.baseBlock.Owner.IsLocal)
                    {
                        BlockHandler.RemoveBlock(face.baseBlock, PhotonNetwork.LocalPlayer);
                    }
                }
                IndexActivated = triggerPressed;
                return;
            }

            PlaceIndicator.SetActive(false);
            DestroyIndicator.SetActive(false);
            LineRenderer.enabled = false;
        }
    }
}
