using System.Collections;
using System.Collections.Generic;
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
    }


    private void OnCollisionEnter(Collision collision)
    {
        //поменять bulletbehaviour на интерфейс ))
        collision.gameObject.GetComponent<BulletBehaviour>().MakeDamage(this);
    }

}
