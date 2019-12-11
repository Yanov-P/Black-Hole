using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitesSpawner : MonoBehaviour
{
    Queue<GameObject> _poolOfBites;

    [SerializeField]
    List<Transform> _listOfTransforms;

    [SerializeField]
    GameObject _instance;

    void Start()
    {
        FillPool();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartSpawn();

        }
    }
    void StartSpawn()
    {
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 0, 1.0f);
    }
    void Spawn()
    {
        GameObject objectToSpawn = _poolOfBites.Dequeue();
        objectToSpawn.transform.localScale = new Vector3(Random.Range(25, 35), Random.Range(25, 35), Random.Range(25, 35));
        objectToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
        var number = Random.Range(0, _listOfTransforms.Count);
        objectToSpawn.transform.position = _listOfTransforms[number].position;
        objectToSpawn.gameObject.SetActive(true);
        _poolOfBites.Enqueue(objectToSpawn);
    }

    public void FillPool()
    {
        _poolOfBites = new Queue<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            GameObject obj = Instantiate(_instance);
            obj.gameObject.SetActive(false);
            _poolOfBites.Enqueue(obj);
        }
    }
}
