using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRequester : MonoBehaviour
{
    [SerializeField]
    List<Transform> _listOfTransforms;
    [SerializeField]
    List<Meteor> m_Meteor;
    Queue<Enemy> _poolOfMeteors;
    public Spawner m_Spawner;
    private Enemy m_Spawn;
    private int m_IncrementorDrone = 0;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartSpawn();
            
        }
        
    }
    private void Start()
    {
        FillPool();
    }
    void StartSpawn()
    {
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 0, 1.5f);
    }

    void Spawn()
    {
        Enemy objectToSpawn = _poolOfMeteors.Dequeue();
        objectToSpawn.gameObject.SetActive(true);
        objectToSpawn.gameObject.GetComponent<Meteor>().enabled = true;
        objectToSpawn.transform.position = _listOfTransforms[Random.Range(0, _listOfTransforms.Count)].position;
        _poolOfMeteors.Enqueue(objectToSpawn);
    }


    public Enemy Create()
    {
        m_Spawn = m_Spawner.SpawnEnemy(m_Meteor[Random.Range(0,m_Meteor.Count)]);
        m_Spawn.name = "Drone_Clone_" + ++m_IncrementorDrone;
        m_Spawn.transform.position = _listOfTransforms[Random.Range(0, _listOfTransforms.Count)].position;
        return m_Spawn;
    }


    public void FillPool()
    {
        _poolOfMeteors = new Queue<Enemy>();
        for (int i = 0; i < 20; i++)
        {
            Enemy obj = Create();
            obj.gameObject.SetActive(false);
            _poolOfMeteors.Enqueue(obj);
        }
    }
}
