﻿using HarmonyLib;
using Photon.Realtime;
using System;
using System.Reflection;

namespace GorillaCraft.Utilities
{
    public static class RigCacheUtils
    {
        private static Assembly GTAssembly => typeof(GorillaTagger).Assembly;

        private static Type RigCacheType => GTAssembly.GetType("VRRigCache");
        private static Type ContainerType => GTAssembly.GetType("RigContainer");

        private static object CacheInstance => AccessTools.Property(RigCacheType, "Instance").GetValue(RigCacheType, null);

        public static RigContainer GetRigContainer(Player player)
        {
            if (CacheInstance == null) return null;

            object[] parameters = [player, null];
            bool method = (bool)AccessTools.Method(RigCacheType, "TryGetVrrig", [typeof(Player), GTAssembly.GetType("RigContainer&")]).Invoke(CacheInstance, parameters);

            if (method)
            {
                return (RigContainer)parameters[1];
                //string propertyName = PropertyName(typeof(T));
                //return (T)AccessTools.Property(ContainerType, propertyName).GetValue(parameters[1]);
            }

            return null;
        }

        private static string PropertyName(Type type) => type.Name switch
        {
            "VRRig" => "Rig",
            "PhotonVoiceView" => "Voice",
            "PhotonView" => "photonView",
            "Boolean" => "Muted",
            "bool" => "Muted",
            _ => throw new IndexOutOfRangeException(type.FullName)
        };
    }
}
