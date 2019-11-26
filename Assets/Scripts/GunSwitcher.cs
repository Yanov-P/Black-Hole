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
        _listOfWeapons.ForEach(k => k.GetComponent<IWeapon>().StopShooting());
        _listOfWeapons[i].GetComponent<IWeapon>().StartShooting();
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
    }
}
