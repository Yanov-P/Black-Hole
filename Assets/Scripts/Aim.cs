using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField]
    GameObject _aim;
    void Start()
    {
        
    }

    void Update()
    {
        int layerMask = 1 << 9;
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 220,layerMask))
        {
            _aim.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z+20);
        }
        else
        {
            _aim.transform.position = new Vector3(transform.position.x, transform.position.y,-200);
        }
        
    }
}
