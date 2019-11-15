using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public Transform transform;
        public int size;
    }

    #region Singleton

    public static ShootingScript Instance;

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

        InvokeRepeating("FullShoot", 0, 0.1f);
    }

    void MakePools()
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

    void FullShoot()
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
            Debug.LogWarning("Pool with tag" + pool.tag + " doesn't exist.");
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
}
