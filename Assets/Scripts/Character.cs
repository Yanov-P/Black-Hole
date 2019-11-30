using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    protected float _maxHealth;

    protected float _currentHealth;

    private void Awake()
    {
       
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
    }
}
