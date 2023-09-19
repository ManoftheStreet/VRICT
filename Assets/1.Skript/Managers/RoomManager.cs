using JetBrains.Annotations;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private string mapType;

    public TextMeshProUGUI OccupancyRateText_ForSchool;
    public TextMeshProUGUI OccupancyRateText_ForOutdoor;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        //방장이 씬을 바꾸면 모든 구성원의 맵이 바뀜
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }

    }


    #region UI Callback Methods

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnEnterButtonClicked_Outdoor()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
                            { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    public void OnEnterButtonClicked_School()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL;

        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
                            { {MultiplayerVRConstants.MAP_TYPE_KEY,mapType } };

        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    #endregion

    #region Photon Callback
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to servers again.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("A room is " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Player " + PhotonNetwork.NickName + " joined to" + PhotonNetwork.CurrentRoom.Name
                        + "Plater count: " + PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("map"))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY, out mapType))
            {
                Debug.Log("Joined room with the map: " + (string)mapType);
                if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL)
                {
                    //load school scene
                    PhotonNetwork.LoadLevel("School");
                }
                else
                {
                    //load outdoor scene
                    PhotonNetwork.LoadLevel("Outdoor");
                }
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to : Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList.Count == 0)
        {
            //There is no room at all
            OccupancyRateText_ForSchool.text = 0 + " / " + 20;
            OccupancyRateText_ForOutdoor.text = 0 + " / " + 20;
        }

        foreach (RoomInfo room in roomList)
        {
            Debug.Log(room.Name);
            if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR))
            {
                //Update the Outdoor room occupancy
                Debug.Log("Room is a Outdoor map. Player count is: " + room.PlayerCount);
                OccupancyRateText_ForOutdoor.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL))
            {
                Debug.Log("Room is a School map. Player count is: " + room.PlayerCount);
                OccupancyRateText_ForSchool.text = room.PlayerCount + " / " + 20;
            }
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined the Lobby.");
    }


    #endregion

    #region Private Methods
    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + mapType + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        string[] roomPropsInLobby = { MultiplayerVRConstants.MAP_TYPE_KEY };
        //We have 2 different maps
        //1.Outdoor = "outdoor"
        //2.School = "school"

        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() 
                    { {MultiplayerVRConstants.MAP_TYPE_KEY , mapType }  };
        
        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;
        
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }


    #endregion
}
