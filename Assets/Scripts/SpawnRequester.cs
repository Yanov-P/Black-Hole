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

    public Vector3 notAllowToSet; 
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
        var number = Random.Range(0, _listOfTransforms.Count);
        SetType(number,objectToSpawn);
        objectToSpawn.transform.position = _listOfTransforms[number].position;//Ето по точкам определенным
        //objectToSpawn.transform.position = GetFreePositions(objectToSpawn);
        objectToSpawn.gameObject.SetActive(true);
        objectToSpawn.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _poolOfMeteors.Enqueue(objectToSpawn);
    }

    public Vector3 GetFreePositions(Enemy objectToSpawn)
    {
        bool mozhno = false;
        while (!mozhno)
        {
            var check = Random.Range(0, 2);
            if (check == 0)
            {
                objectToSpawn.transform.position = new Vector3(Random.Range(-640, -630), Random.Range(5, 20), -1000);
            }
            else
            {
                objectToSpawn.transform.position = new Vector3(Random.Range(-670, -660), Random.Range(-20, -5), -1000);
            }

            if(objectToSpawn.transform.position.x<notAllowToSet.x+12.5f && objectToSpawn.transform.position.x > notAllowToSet.x - 12.5f &&
                objectToSpawn.transform.position.y < notAllowToSet.y - 12.5f && objectToSpawn.transform.position.y > notAllowToSet.y + 12.5f)
            {
                mozhno = true; 
            }
        }
        return objectToSpawn.transform.position;
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
