using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace GorillaCraft.Extensions
{
    public static class PhotonExtentions
    {
        public static bool IsValid(this PhotonMessageInfo info) => info.photonView.Owner == info.Sender;

        public static bool IsValid(this PhotonStream stream)
        {
            if (stream.IsWriting)
            {
                List<object> writeData = (List<object>)AccessTools.Field(stream.GetType(), "writeData").GetValue(stream);
                return writeData != null && writeData.Count > 0;
            }

            object[] readData = (object[])AccessTools.Field(stream.GetType(), "readData").GetValue(stream);
            return readData != null && readData.Length > 0; 
        }
    }
}
