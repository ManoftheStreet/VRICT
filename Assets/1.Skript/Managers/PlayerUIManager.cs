using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject GoHome_Button;

    void Start()
    {
        GoHome_Button.GetComponent<Button>().onClick.AddListener(VirtualWorldManager.Instance.LeaveRoomAndLoadHomeScene);
    }

    void Update()
    {

    }
}
