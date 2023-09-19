using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject GenericVRPlayerPrefab;

    public Vector3 spawnPosition;

    private bool tryToConnectAgain = false;
    private float timeToReconnect = 5.0f;
    private float timer = 0.0f;

    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("!IsConnectedAndReady");
            tryToConnectAgain = true;
        }
    }

    void Update()
    {
        if (tryToConnectAgain)
        {
            timer += Time.deltaTime;
            if (timer > timeToReconnect)
            {
                timer = 0;
                // Your logic to reconnect
                // ¿¹: PhotonNetwork.ConnectUsingSettings();
                Debug.Log("Trying to reconnect...");
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Reconnected to the server.");
        tryToConnectAgain = false;
        PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPosition, Quaternion.identity);
    }

}
