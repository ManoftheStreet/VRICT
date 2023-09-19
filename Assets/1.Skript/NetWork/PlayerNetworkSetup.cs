using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameobject;

    //public GameObject AvatarHeadGameObject;
    //public GameObject AvatarBodyGameObject;

    void Start()
    {
        if (photonView.IsMine)
        {
            //The player is local
            LocalXRRigGameobject.SetActive(true);

            //SetLayerRecursively(AvatarHeadGameObject, 6);
            //SetLayerRecursively(AvatarBodyGameObject, 7);
        }
        else 
        {
            //The Player is remote
            LocalXRRigGameobject.SetActive(false);
            //SetLayerRecursively(AvatarHeadGameObject, 0);
            //SetLayerRecursively(AvatarBodyGameObject, 0);
        }
    }

    void Update()
    {

    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
