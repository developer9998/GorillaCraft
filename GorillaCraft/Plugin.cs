using BepInEx;
using GorillaCraft.Behaviours;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaLibrary;
using GorillaLibrary.Attributes;
using GorillaLibrary.Models;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using PluginInfo = BepInEx.PluginInfo;

namespace GorillaCraft;

[BepInPlugin("dev.gorillacraft", "GorillaCraft", "1.0.0.9")]
[BepInDependency("dev.gorillalibrary"), ModdedGamemode]
public class Plugin : BaseUnityPlugin
{
    public static Watchable<bool> InModdedRoom;

    public static new PluginInfo Info;

    public void Awake()
    {
        InModdedRoom = new Watchable<bool>();
        Info = base.Info;

        Logging.Logger = Logger;

        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), Info.Metadata.GUID);

        Events.Core.OnGameInitialized += OnGameInitialied;
        Events.Rig.OnRigAdded += OnRigAdded;
        Events.Rig.OnRigRemoved += OnRigRemoved;
    }

    public void OnGameInitialied()
    {
        AssetLoaderSync assetLoader = new(Assembly.GetExecutingAssembly(), Constants.BundleDirectory);

        Configuration config = new(Config);

        BlockContainerObject blockContainer = assetLoader.LoadAsset<BlockContainerObject>("Blocks");

        GameObject modObject = new($"{Info.Metadata.Name} {Info.Metadata.Version}");

        BlockScript blockScript = modObject.AddComponent<BlockScript>();
        blockScript.AssetLoader = assetLoader;
        blockScript.Config = config;
        blockScript.BlockContainer = blockContainer;

        BuildScript buildScript = modObject.AddComponent<BuildScript>();
        buildScript.AssetLoader = assetLoader;
        buildScript.BlockScript = blockScript;
        buildScript.Blocks = [.. blockContainer.Blocks];

        MainScript mainScript = modObject.AddComponent<MainScript>();
        mainScript.AssetLoader = assetLoader;
        mainScript.Config = config;

        DontDestroyOnLoad(modObject);
    }

    public void OnRigAdded(VRRig rig, NetPlayer player)
    {
        if (rig.GetComponent<GorillaCrafter>()) return;
        rig.gameObject.AddComponent<GorillaCrafter>();
    }

    public void OnRigRemoved(VRRig rig)
    {
        if (!rig.TryGetComponent(out GorillaCrafter component)) return;
        component.Remove();
    }

    [ModdedGamemodeJoin]
    public void OnJoinModded()
    {
        InModdedRoom.value = true;
    }

    [ModdedGamemodeLeave]
    public void OnLeaveModded()
    {
        InModdedRoom.value = false;
    }
}