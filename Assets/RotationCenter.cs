using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCenter : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotationVector = new Vector3(0, 0, 0.01f);
    private void Update()
    {
        transform.Rotate(_rotationVector, Space.Self);
    }
}
