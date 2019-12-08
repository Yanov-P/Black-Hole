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
        foreach(var k in _listOfTransforms)
        {
            Debug.Log(k.position);
        }
    }
    void StartSpawn()
    {
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 0, 1.5f);
    }

    void Spawn()
    {
        Enemy objectToSpawn = _poolOfMeteors.Dequeue();
        var number = Random.Range(0, _listOfTransforms.Count);
        SetType(number,objectToSpawn);
        objectToSpawn.transform.position = _listOfTransforms[number].position;
        objectToSpawn.gameObject.SetActive(true);
        _poolOfMeteors.Enqueue(objectToSpawn);
    }


    public Enemy Create()
    {
        m_Spawn = m_Spawner.SpawnEnemy(m_Meteor[Random.Range(0,m_Meteor.Count)]);
        m_Spawn.name = "Asteroid" + ++m_IncrementorDrone;
        return m_Spawn;
    }


    void SetType(int number, Enemy m_Spawn)
    {
        if (number > 9)
        {
            (m_Spawn as Meteor)._typeOfMeteor = Meteor.Type.circle;
        }
        else
        {
            (m_Spawn as Meteor)._typeOfMeteor = Meteor.Type.simple;
        }
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
