using GorillaCraft.Interfaces;
using Photon.Realtime;
using UnityEngine;

namespace GorillaCraft.Behaviours.Block
{
    public class BlockParent : MonoBehaviour
    {
        public Player Owner;
        public IBlock Block;

        public BlockFace Back, Left, Front, Right, Bottom, Top;

        public void Destroy()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            Destroy(gameObject, 5f);
        }
    }
}
