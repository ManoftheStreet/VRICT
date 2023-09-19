using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{ 
    public Transform cameraTransform;

    void Update()
    {
        // 이 오브젝트의 위치를 카메라 위치로 설정
        transform.position = cameraTransform.position;

        // 이 오브젝트의 회전을 카메라 회전으로 설정
        transform.rotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);
    }
}
