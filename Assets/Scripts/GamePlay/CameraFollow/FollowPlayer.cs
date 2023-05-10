using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // public Transform FollowTo;
    public Transform followTo;
    public Vector3 Offset;
    public float CameraDistance;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(followTo.position.x, followTo.position.y, CameraDistance);
    }
}
