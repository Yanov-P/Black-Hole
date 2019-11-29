using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRequester : MonoBehaviour
{
    [SerializeField]
    List<Transform> _listOfTransforms;
    [SerializeField]
    List<GameObject> _listOfMeshes;
    [SerializeField]
    Material _asteroidMaterial;
    [SerializeField]
    List<Meteor> m_Meteor;

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
        if (Spawner._poolOfMeteors.Count < 10 || Spawner._poolOfMeteors.ContainsValue(true))
        {
            m_Spawn = m_Spawner.SpawnEnemy(m_Meteor[Random.Range(0,m_Meteor.Count)]);
            m_Spawn.gameObject.SetActive(true);
            m_Spawn.name = "Drone_Clone_" + ++m_IncrementorDrone;
            m_Spawn.transform.position = _listOfTransforms[Random.Range(0, _listOfTransforms.Count)].position;
            m_Spawn.GetComponent<MeshRenderer>().enabled = true;
            m_Spawn.GetComponent<MeshCollider>().enabled = true;
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }
}
