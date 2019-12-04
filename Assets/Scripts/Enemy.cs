using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : Character, ICopyable
{
    
    public ICopyable Copy()
    {
        return Instantiate(this);
    }

    public virtual void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ICartridge>() != null)
        {
            collision.gameObject.GetComponent<ICartridge>().MakeDamage(this);
        }
        if (collision.collider.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.GetComponent<Meteor>().enabled = false;
            gameObject.GetComponent<Meteor>().FullDestroy();
        }
    }
}
