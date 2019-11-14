using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    //private Transform _blackHole;
    //private float _distanceToHole;
    //private float _currentAngle = 0;
    //private float _angularSpeed = 0.01f;
    //void Start()
    //{
    //    _distanceToHole = new Vector2(Mathf.Abs(_blackHole.position.x - transform.position.x), Mathf.Abs(_blackHole.position.z - transform.position.z)).magnitude;
    //}

    //void Update()
    //{
    //    transform.position = new Vector3(_distanceToHole * Mathf.Sin(_currentAngle), transform.position.y, _distanceToHole * Mathf.Cos(_currentAngle));
    //    _currentAngle += _angularSpeed;
    //}
    void Start()
    {
        Debug.Log("player movement");
    }
}
