using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Utilities;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace GorillaCraft.Patches
{
    [HarmonyPatch]
    public class RigPatch
    {
        public static async void AddPatch(Player player)
        {
            PhotonView photonView = RigCacheUtils.GetField<PhotonView>(player);

            while (photonView == null)
            {
                photonView = RigCacheUtils.GetField<PhotonView>(player);
                await Task.Delay(200);

                if (!PhotonNetwork.InRoom)
                {
                    return;
                }
            }
            photonView.gameObject.AddComponent<PlayerSerializer>();
        }
    }
}
