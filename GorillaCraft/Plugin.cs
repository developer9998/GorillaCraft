﻿using BepInEx;
using Bepinject;
using GorillaCraft.Models;
using GorillaCraft.Patches;
using HarmonyLib;
using System;
using System.Reflection;
using Utilla;

namespace GorillaCraft
{
    // Methods are made asynchronous to avoid potential decompilations (I've never heard a single cheater utter the word "ilspy" shut up)
    [ModdedGamemode, BepInPlugin(Constants.GUID, Constants.Name, Constants.Version), BepInIncompatibility("dev.devminecraftinternal"), BepInIncompatibility("org.iidk.gorillatag.iimenu")]
    public class Plugin : BaseUnityPlugin
    {
        public static Watchable<bool> Allowed { get; private set; }

        private static Assembly GTAssembly => typeof(GorillaTagger).Assembly;
        private static Type RigPatchType => typeof(AddPlayerPatch);

        public async void Awake()
        {
            Allowed = new Watchable<bool>();

            Zenjector.Install<MainInstaller>().OnProject().WithConfig(Config).WithLog(Logger);

            Harmony harmony = new(Constants.GUID);
            harmony.PatchAll(typeof(Plugin).Assembly);

            Type rigCacheType = GTAssembly.GetType("VRRigCache");
            harmony.Patch(AccessTools.Method(rigCacheType, "AddRigToGorillaParent"), postfix: new HarmonyMethod(RigPatchType, nameof(AddPlayerPatch.AddPatch)));
        }

        [ModdedGamemodeJoin]
        public async void OnJoin()
        {
            Allowed.value = true;
        }

        [ModdedGamemodeLeave]
        public async void OnLeave()
        {
            Allowed.value = false;
        }
    }
}
