using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRequester : MonoBehaviour
{
    [SerializeField]
    List<Transform> _listOfTransforms;
    public Meteor m_Meteor;
    public Spawner m_Spawner;
    private Enemy m_Spawn;
    private int m_IncrementorDrone = 0;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartSpawn();
            Debug.Log(Spawner._poolOfMeteors.Count);
        }
        
    }

    void StartSpawn()
    {
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 0, 1.5f);
    }

    public void Spawn()
    {
        m_Spawn = m_Spawner.SpawnEnemy(m_Meteor);
        m_Spawn.gameObject.SetActive(true);
        m_Spawn.name = "Drone_Clone_" + ++m_IncrementorDrone;
        m_Spawn.transform.position = _listOfTransforms[Random.Range(0, _listOfTransforms.Count)].position;
    }
}
