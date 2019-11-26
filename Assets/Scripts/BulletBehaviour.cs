using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour,ICartridge
{
    [SerializeField]
    float _bulletsDamage;
    public void MakeDamage(Enemy enemy)
    {
        enemy.TakeDamage(_bulletsDamage);
    }
}
