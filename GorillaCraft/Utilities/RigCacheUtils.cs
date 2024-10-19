using HarmonyLib;
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
            AccessTools.Method(RigCacheType, "TryGetVrrig", [typeof(Player), GTAssembly.GetType("RigContainer&")]).Invoke(CacheInstance, parameters);
            return (RigContainer)parameters[1] ?? null;
        }
    }
}
