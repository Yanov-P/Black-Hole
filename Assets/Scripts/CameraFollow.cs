using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothSpeed = 0.125f;
    [SerializeField]
    private Vector3 offset;

    void LateUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position, smoothSpeed);
        Vector3 t = target.position;
        target.position = smoothedPosition;
        transform.LookAt(target);
        target.position = t;
    }
}
