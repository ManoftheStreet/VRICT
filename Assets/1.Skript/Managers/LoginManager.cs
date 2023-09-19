using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField PlayerName_InputName;

    #region unityMehods
    void Start()
    {
        
    }

    void Update()
    {

    }
    #endregion


    #region UI Callback Methods
    public void ConnectAnonymously()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToPhotonServer()
    {
        if(PlayerName_InputName != null)
        {
            PhotonNetwork.NickName = PlayerName_InputName.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }



    #endregion

    #region Photon Callback Methods
    public override void OnConnected()
    {
        Debug.Log("sever ok");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server"+PhotonNetwork.NickName);
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected from server for reason: " + cause.ToString());
        // ���⿡ ����ڿ��� ������ �������� �˸��� UI �ڵ带 �߰��� �� �ֽ��ϴ�.
    }

    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
        Debug.LogError("Custom Authentication Failed: " + debugMessage);
        // ���⿡ ���� ���п� ���� ó���� �߰��� �� �ֽ��ϴ�.
    }

    #endregion
}
