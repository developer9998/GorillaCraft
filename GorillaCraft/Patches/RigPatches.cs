using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Utilities;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;

namespace GorillaCraft.Patches
{
    [HarmonyPatch]
    public class RigPatches
    {
        public static async void AddPatch(Player player, VRRig vrrig)
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

        public static void RemovePatch(Player player, VRRig vrrig)
        {
            //PhotonView photonView = RigCacheUtils.GetField<PhotonView>(player);
            //Object.Destroy(photonView.GetComponent<PlayerSerializer>());
        }
    }
}
