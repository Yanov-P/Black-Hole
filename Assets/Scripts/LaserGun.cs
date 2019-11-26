using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour,  IWeapon
{
    public void MakePools()
    {
        throw new System.NotImplementedException();
    }

    public void MakeSound()
    {
        throw new System.NotImplementedException();
    }

    public void SetWeapon()
    {
        throw new System.NotImplementedException();
    }

    public GameObject Shoot(Pool pool)
    {
        throw new System.NotImplementedException();
    }

    public void StartAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void StartShooting()
    {
        gameObject.SetActive(true);
    }

    public void StopAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void StopShooting()
    {
        gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
