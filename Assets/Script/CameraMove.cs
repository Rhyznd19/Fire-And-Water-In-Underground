using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothcamera;
    // Update is called once per frame
    void FixedUpdate()
    {
        Camera();
    }

    private void Camera()
    {
        Vector3 Player = player.position + offset;
        Vector3 smooth = Vector3.Lerp(transform.position, Player, smoothcamera * Time.fixedDeltaTime);
        transform.position = smooth;
    }
}

