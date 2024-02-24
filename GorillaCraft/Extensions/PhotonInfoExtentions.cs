using Photon.Pun;

namespace GorillaCraft.Extensions
{
    public static class PhotonInfoExtentions
    {
        public static bool IsValid(this PhotonMessageInfo info) => info.Sender == info.photonView.Owner;
    }
}
