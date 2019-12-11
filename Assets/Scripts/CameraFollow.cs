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
        
        Vector3 t = target.position;
        target.position = t;
        Vector3 newTarget = new Vector3((t.x + 650) / 20.0f - 650, (t.y + offset.y) / 20.0f - 0, 0);
        transform.LookAt(newTarget);
    }
}
