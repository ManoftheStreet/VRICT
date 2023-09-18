using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapTransforms
{
    public Transform vrTargets;
    public Transform ikTarget;

    public Vector3 trackingpositionOffset;
    public Vector3 trackingRotationOffset;

    public void VRMapping()
    {
        ikTarget.position = vrTargets.TransformPoint(trackingpositionOffset);
        ikTarget.rotation = vrTargets.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class AvatarController : MonoBehaviour
{
    [SerializeField] private MapTransforms head;
    [SerializeField] private MapTransforms leftHand;
    [SerializeField] private MapTransforms rightHand;

    [SerializeField] private float turnSmoothness;
    [SerializeField] Transform ikHead;
    [SerializeField] Vector3 headBodyOffset;

    private void LateUpdate()
    {
        transform.position = ikHead.position + headBodyOffset;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(ikHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.VRMapping();
        leftHand.VRMapping();
        rightHand.VRMapping();
    }

}
