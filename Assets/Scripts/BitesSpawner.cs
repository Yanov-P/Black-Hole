using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitesSpawner : MonoBehaviour
{
    Queue<GameObject> _poolOfBites;
    public SpawnRequester _spawnRequester;
    [SerializeField]
    List<Mesh> _listOfMeshes;
    [SerializeField]
    GameObject _instance;

    void Start()
    {
        FillPool();
        Invoke("StartSpawn",5f);
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
        InvokeRepeating("Spawn", 0, 1.5f);
    }

    private void ResetBite(GameObject objectToSpawn)
    {
        objectToSpawn.GetComponent<MeshFilter>().mesh = _listOfMeshes[Random.Range(0, _listOfMeshes.Count)];
        objectToSpawn.GetComponent<MeshCollider>().sharedMesh = objectToSpawn.GetComponent<MeshFilter>().mesh;
        objectToSpawn.transform.eulerAngles = Vector3.zero;
        objectToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
        var check = Random.Range(0, 2);
        if (check == 0)
        {
            objectToSpawn.transform.position = new Vector3(Random.Range(-645, -640), Random.Range(5, 30), -1000);
        }
        else
        {
            objectToSpawn.transform.position = new Vector3(Random.Range(-660, -655), Random.Range(-35, -5), -1000);
        }
        objectToSpawn.gameObject.SetActive(true);
    }
    void Spawn()
    {
        GameObject objectToSpawn = _poolOfBites.Dequeue();
        ResetBite(objectToSpawn);
        _spawnRequester.notAllowToSet = objectToSpawn.transform.position;
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
