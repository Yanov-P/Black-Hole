using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitesMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, 1.5f);
    }
}
