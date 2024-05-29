using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;

namespace GorillaCraft.Patches
{
    [HarmonyPatch]
    public class AddPlayerPatch
    {
        public static async void AddPatch(NetPlayer player)
        {
            await Task.Delay(300);

            if (player is PunNetPlayer punNetPlayer)
            {
                Player realtimePlayer = punNetPlayer.playerRef;
                PhotonView photonView = RigCacheUtils.GetProperty<PhotonView>(realtimePlayer);

                // retry the attempt of collecting the photonview from our realtime-player
                while (realtimePlayer.InRoom() && photonView == null)
                {
                    photonView = RigCacheUtils.GetProperty<PhotonView>(realtimePlayer);
                    await Task.Delay(50);
                }

                if (PhotonNetwork.InRoom) photonView.gameObject.AddComponent<PlayerSerializer>();
            }
            else
            {
                Logging.Log(string.Format("PunNetPlayer class not inherited by NetPlayer of {0}. GorillaCraft serialzation may not be done.", player.NickName), BepInEx.Logging.LogLevel.Warning);
            }
        }
    }
}
