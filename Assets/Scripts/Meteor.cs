using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Meteor : Enemy
{
   
    private void Start()
    {
        transform.localScale *= Random.Range(1, 3);
        _maxHealth = transform.localScale.x;
        _currentHealth = _maxHealth;
        Debug.Log(_currentHealth);
    }
    public void Update()
    {
        Move();
        if (transform.position.z > 20)
        {
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        transform.eulerAngles += new Vector3(0, 7, 0);
        transform.position += new Vector3(0, 0, 0.6f);
    }

    public override void TakeDamage(float damage)
    {
        (this as Character).TakeDamage(damage);
        if(_currentHealth <= 0)
        {
            _currentHealth = _maxHealth;
            gameObject.SetActive(false);
        }
    }

}
