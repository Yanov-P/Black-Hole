using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Meteor : Enemy
{
   
    private void Start()
    {
        _maxHealth = transform.localScale.x;
        _currentHealth = _maxHealth;
        
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


    public override void TakeDamage(float damage)
    {
        (this as Character).TakeDamage(damage);
        if(_currentHealth <= 0)
        {
            var instance = Spawner._poolOfMeteors.First(kvp => (Object)kvp.Key == this).Key;
            Spawner._poolOfMeteors[instance] = true;
            _currentHealth = _maxHealth;
            gameObject.SetActive(false);
        }
    }

}
