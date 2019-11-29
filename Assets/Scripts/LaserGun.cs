using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour,  IWeapon
{
    public Transform  firePoint;
    public LineRenderer lR;
    float distance;
    int i = 0;
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
        distance = 0;
        gameObject.SetActive(true);
        InvokeRepeating("Shoot", 0, Time.deltaTime);
    }

    public void StopAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void StopShooting()
    {
        gameObject.SetActive(false);
        CancelInvoke("Shoot");
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, distance))
        {
            
            lR.SetPosition(0, new Vector3(0, 0, 0));
            lR.SetPosition(1, Vector3.forward * hit.distance);
            distance = hit.distance;
            i++;
            if (i % 2 == 0 && hit.collider.gameObject.layer == 9)
            {
                hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(1);
            }
        }
        else
        {
            lR.SetPosition(0, new Vector3(0, 0, 0));
            lR.SetPosition(1, Vector3.forward * distance);
            if (distance < 500) distance += 10f;
        }
    }
}
