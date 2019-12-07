using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Character
{
    public static Ship Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _maxHealth = 10;
        _currentHealth = _maxHealth;
    }

    
    public void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (_currentHealth <= 0)
        {
            Debug.Log("End");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 9)
        {
            TakeDamage(1);
            
        }
    }


}
