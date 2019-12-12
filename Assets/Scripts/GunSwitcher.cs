using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public List<GameObject> _listOfWeapons;
    /*
     0 - simple
     1- laser
         */
    public void SwitchWeapon(int i)
    {
        OffAllWeapons();
        _listOfWeapons[i].GetComponent<IWeapon>().StartShooting();
    }


    public void StartWeapon()
    {
        SwitchWeapon(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            OffAllWeapons();
        }
    }

    public void OffAllWeapons()
    {
        _listOfWeapons.ForEach(k => k.GetComponent<IWeapon>().StopShooting());
    }

    
}
