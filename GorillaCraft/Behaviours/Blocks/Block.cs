using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaExtensions;
using GorillaLibrary.Extensions;
using GorillaLibrary.Utilities;
using HarmonyLib;
using System;
using System.Linq;
using UnityEngine;

namespace GorillaCraft.Behaviours.Blocks;

/// <summary>
/// BlockObject is a physical object placed by GorillaCraft, with six sides, and a specified owner.
/// </summary>
public class Block : MonoBehaviour
{
    public Guid SerialNumber;

    /// <summary>
    /// The owner who is currently in possession of the block.
    /// </summary>
    public NetPlayer Owner;

    /// <summary>
    /// The type of IBlock this block identifies with.
    /// </summary>
    public BlockObject Reference;

    /// <summary>
    /// A <see cref="BlockFace"/>, a physical component given to a face of the block.
    /// </summary>
    public BlockFace Back, Left, Front, Right, Bottom, Top;

    private BlockFace[] _array;

    public BlockFace this[byte index]
    {
        get
        {
            return index switch
            {
                1 => Front,
                2 => Back,
                3 => Left,
                4 => Right,
                5 => Top,
                6 => Bottom,
                _ => throw new IndexOutOfRangeException()
            };
        }
    }

    /// <summary>
    /// A list of blocks which currently possess this block (i.e. a block holding up a ladder)
    /// </summary>
    public Block ParentalBlock;

    private bool isDestroy;

    public Vector3 Position, EulerAngles;

    public float Size;

    /// <summary>
    /// When read, IsLocal will return whether this BlockObject is owned by the local player.
    /// </summary>
    public bool IsLocal => Owner == null || Owner.IsLocal;

    public void Start()
    {
        MainScript.BlockScript.AddPosition(Position, IsLocal);
    }

    public void Destroy(bool useDestroyEffects = true)
    {
        if (isDestroy) return;
        isDestroy = true;

        try
        {
            RemoveChildren(useDestroyEffects);
            if (ParentalBlock.IsObjectExistent()) ParentalBlock.CheckChildren(this);
        }
        catch (Exception ex)
        {
            Logging.Error(ex);
        }

        if (RigUtility.TryGetRig(Owner, out RigContainer playerRig) && playerRig.TryGetComponent(out GorillaCrafter component) && component.Blocks.ContainsKey(SerialNumber))
            component.Blocks.Remove(SerialNumber);

        MainScript.BlockScript.RemovePosition(Position);

        if (useDestroyEffects)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            Destroy(gameObject, 5f);
            return;
        }

        Destroy(obj: gameObject);
    }

    public void RemoveChildren(bool useDestroyEffects)
    {
        _array ??= [Front, Back, Left, Right, Top, Bottom];
        _array.ForEach(face => RemoveChildren(face, useDestroyEffects));
    }

    private void RemoveChildren(BlockFace face, bool useDestroyEffects)
    {
        // this goes through, we're a parent to one or more children blocks
        if (face.IsObjectExistent() && face.ChildBlocks.Any())
        {
            var children = face.ChildBlocks.ToArray();
            children.DoIf(block => !block.IsNull(), block => block.Destroy(useDestroyEffects));
        }
    }

    public void CheckChildren(Block child)
    {
        _array ??= [Front, Back, Left, Right, Top, Bottom];
        _array.ForEach(face => CheckChildren(face, child));
    }

    private void CheckChildren(BlockFace face, Block child)
    {
        if (face.IsObjectExistent() && face.ChildBlocks.Contains(child)) face.ChildBlocks.Remove(child);
    }

    public BlockFace FindChildFace(Block child)
    {
        _array ??= [Front, Back, Left, Right, Top, Bottom];
        foreach (var face in _array)
        {
            if (face.ChildBlocks.Count == 0) continue;
            if (face.ChildBlocks.Contains(child)) return face;
        }
        return null;
    }

    public byte GetIndex(BlockFace face)
    {
        _array ??= [Front, Back, Left, Right, Top, Bottom];
        return Array.IndexOf(_array, face) is int index && index != -1 ? Convert.ToByte(index + 1) : Convert.ToByte(0);
    }
}
