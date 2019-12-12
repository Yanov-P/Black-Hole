using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : Character
{
    [SerializeField]
    Text _hpText;

    public static Ship Instance;

    public GunSwitcher _gunSwitcher;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _maxHealth = 10;
        _currentHealth = _maxHealth;
        _hpText.text = _currentHealth.ToString();
    }

    
    public void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        _hpText.text = _currentHealth.ToString();
        if (_currentHealth <= 0)
        {
            _hpText.text = "Death";
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 9 || collision.collider.gameObject.tag == "Bites")
        {
            TakeDamage(1);
        }
    }


}
