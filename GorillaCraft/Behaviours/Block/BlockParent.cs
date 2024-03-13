using GorillaCraft.Interfaces;
using HarmonyLib;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GorillaCraft.Behaviours.Block
{
    public class BlockParent : MonoBehaviour
    {
        public Player Owner;
        public IBlock Block;

        public BlockFace Back, Left, Front, Right, Bottom, Top;

        public List<BlockParent> GuardianBlocks = new(), InflictedBlocks = new();

        public void Destroy()
        {
            if (InflictedBlocks.Count > 0) InflictedBlocks.Do(block =>
            {
                block.GuardianBlocks.Remove(this);
                block.Destroy();
            });
            else if (GuardianBlocks.Count > 0) GuardianBlocks.Where(block => block.InflictedBlocks.Count > 0 && block.InflictedBlocks.Contains(this)).Do(block => block.InflictedBlocks.Remove(this));

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            Destroy(gameObject, 5f);
        }
    }
}
