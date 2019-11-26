using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour, ICopyable
{
    protected float hp;
    public ICopyable Copy()
    {
        return Instantiate(this);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            var instance = Spawner._poolOfMeteors.First(kvp => (Object)kvp.Key == this).Key;
            Spawner._poolOfMeteors[instance] = true;
            hp = 10;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<ICartridge>().MakeDamage(this);
    }
}
