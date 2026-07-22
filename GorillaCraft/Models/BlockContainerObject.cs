using UnityEngine;

namespace GorillaCraft.Models
{
    [CreateAssetMenu(fileName = "Block Container", menuName = "GorillaCraft/Block Container")]
    public class BlockContainerObject : ScriptableObject
    {
        public BlockObject[] Blocks;
    }

}