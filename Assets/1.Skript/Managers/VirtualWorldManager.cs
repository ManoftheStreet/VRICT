using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{
    #region Photon Callback

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to : Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion

}
