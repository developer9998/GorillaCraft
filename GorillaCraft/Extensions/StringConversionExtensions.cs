using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;

namespace GorillaCraft.Extensions
{
    public static class StringConversionExtensions
    {
        public static string String(this Exception exception) => string.Join(" ", exception.Message, exception.GetBaseException().StackTrace);

        public static string String(this EventData eventData)
        {
            Player player = PhotonNetwork.CurrentRoom.GetPlayer(eventData.Sender);
            return string.Format("({0} - #{1} {2}/{3}) ", eventData.Code, eventData.Sender, player.NickName, player.UserId);
        }
    }
}
