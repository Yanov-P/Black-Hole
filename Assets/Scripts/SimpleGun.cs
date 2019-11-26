using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleGun : MonoBehaviour, IWeapon
{
    #region Singleton

    public static SimpleGun Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        MakePools();
    }

   

    public void StartShooting()
    {
        CancelInvoke("SetOffBullets");

        InvokeRepeating("FullShoot", 0, 0.1f);
    }

    public void StopShooting()
    {
        CancelInvoke("FullShoot");
        Invoke("SetOffBullets", 2);
    }

    public void SetOffBullets()
    {
        foreach (Pool pool in pools)
        {
            foreach (GameObject element in poolDictionary[pool.tag])
            {
                element.SetActive(false);
            }
        }
    }

    public void MakePools()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public void FullShoot()
    {
        foreach (Pool pool in pools)
        {
            Shoot(pool);
        }
    }

    public GameObject Shoot(Pool pool)
    {
        if (!poolDictionary.ContainsKey(pool.tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[pool.tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pool.transform.position;
        objectToSpawn.transform.rotation = pool.transform.rotation;

        objectToSpawn.GetComponent<Rigidbody>().velocity = objectToSpawn.transform.TransformDirection(new Vector3(0, 0, -100));
        poolDictionary[pool.tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public void MakeSound()
    {
        throw new System.NotImplementedException();
    }

    public void StartAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void StopAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void SetWeapon()
    {
        throw new System.NotImplementedException();
    }
}
