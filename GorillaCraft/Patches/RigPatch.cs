using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Utilities;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System;
using GorillaCraft.Extensions;

namespace GorillaCraft.Patches
{
    [HarmonyPatch]
    public class RigPatch
    {
        public static async void AddPatch(Player player)
        {
            await Task.Delay(400);

            PhotonView photonView = RigCacheUtils.GetField<PhotonView>(player);

            while (photonView == null && PhotonNetwork.InRoom)
            {
                photonView = RigCacheUtils.GetField<PhotonView>(player);
                await Task.Delay(50);
            }

            if (PhotonNetwork.InRoom && player.InRoom())
            {
                photonView.gameObject.GetOrAddComponent<PlayerSerializer>();

            }
        }
    }
}
