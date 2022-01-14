using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float smoothTime = 0.1f;

    Vector3 currentVelocity = Vector3.zero;

    public Vector3 offset = new Vector3(0, 0, -10);

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);
        transform.position = position;
    }
}
