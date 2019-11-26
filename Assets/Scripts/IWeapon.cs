using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{

    void SetWeapon();
    void StartAnimation();
    void StopAnimation();
    void MakeSound();
    void StopShooting();
    void StartShooting();
    void MakePools();
    GameObject Shoot(Pool pool);
}

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public Transform transform;
    public int size;
}