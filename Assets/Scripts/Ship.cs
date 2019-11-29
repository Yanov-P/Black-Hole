using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Character
{

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
        Debug.Log("here");
        if(collision.gameObject.layer == 9)
        {
            TakeDamage(1);
            Debug.Log("kasd");
        }
    }
}
