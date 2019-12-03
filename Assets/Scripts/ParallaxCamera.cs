using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    private void Start()
    {
        _target.position = new Vector3(_target.position.x, _target.position.y, _target.position.z + 20);
        transform.position = _target.position;
    }

    private void Update()
    {
        
    }
}
