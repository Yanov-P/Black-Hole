using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Meteor : Enemy
{
    
    private void Start()
    {
        hp = 10;
        
    }
    public void Update()
    {
        transform.eulerAngles += new Vector3(0, 10, 0);
        transform.position += new Vector3(0, 0, 1f);
        if (transform.position.z > 20)
        {
            Spawner._poolOfMeteors[this] = true;
            gameObject.SetActive(false);
        }
    }


    

}
