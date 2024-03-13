using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Extensions;
using GorillaCraft.Utilities;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;

namespace GorillaCraft.Patches
{
    [HarmonyPatch]
    public class RigPatch
    {
        public static async void AddPatch(Player player)
        {
            await Task.Delay(400);

            PhotonView photonView = RigCacheUtils.GetProperty<PhotonView>(player);

            while (photonView == null && PhotonNetwork.InRoom)
            {
                photonView = RigCacheUtils.GetProperty<PhotonView>(player);
                await Task.Delay(50);
            }

            if (PhotonNetwork.InRoom && player.InRoom())
            {
                photonView.gameObject.GetOrAddComponent<PlayerSerializer>();

            }
        }
    }
}
