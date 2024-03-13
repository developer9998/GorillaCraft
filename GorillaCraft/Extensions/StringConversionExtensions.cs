using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Reflection;

namespace GorillaCraft.Extensions
{
    public static class StringConversionExtensions
    {
        public static string String(this MethodBase methodInfo) => string.Format("({0}.{1}()) ", methodInfo.ReflectedType.Name, methodInfo.Name).Replace("<LoadAsset>d__5`1.MoveNext()", "AssetLoader.LoadAsset()");

        public static string String(this Exception exception) => string.Join(" ", exception.Message, exception.GetBaseException().StackTrace);

        public static string String(this EventData eventData)
        {
            Player player = PhotonNetwork.CurrentRoom.GetPlayer(eventData.Sender);
            return string.Format("({0} - #{1} {2}/{3}) ", eventData.Code, eventData.Sender, player.NickName, player.UserId);
        }
    }
}
