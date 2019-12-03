using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Meteor : Enemy
{
    Dictionary<GameObject, Vector3> _particlesStates = new Dictionary<GameObject, Vector3>();
    bool _wasStarted = false;
    private void Start()
    {
        foreach (Transform particle in transform.GetChild(0).transform)
        {
            var vector = new Vector3(particle.gameObject.transform.localPosition.x, 
                particle.gameObject.transform.localPosition.y, particle.gameObject.transform.localPosition.z);
            _particlesStates.Add(particle.gameObject, vector);
        }
        transform.localScale *= Random.Range(1, 3);
        _maxHealth = transform.localScale.x;
        _currentHealth = _maxHealth;
        _wasStarted = true;
    }
    public void Update()
    {
        Move();
        if (transform.position.z > 20)
        {
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        transform.eulerAngles += new Vector3(0, 3, 0);
        transform.position += new Vector3(0, 0, 3f);
    }

    public override void TakeDamage(float damage)
    {
        (this as Character).TakeDamage(damage);
        if(_currentHealth <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.GetComponent<Meteor>().enabled = false;
            FullDestroy();
        }
    }

    private void OnEnable()
    {
        if (_wasStarted)
        {
            _currentHealth = _maxHealth;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(false);
            ResetParticles();
        }
    }

    private void ResetParticles()
    {
        foreach (Transform particle in transform.GetChild(0).transform)
        {
            particle.localPosition = _particlesStates[particle.gameObject];
            particle.localRotation = Quaternion.Euler(0, 0, 0);
            particle.gameObject.GetComponent<Rigidbody>().velocity =Vector3.zero;
        }
    }

    public void FullDestroy()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        foreach (Transform child in transform.GetChild(0).transform)
        {
            child.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-50, 60), Random.Range(-50,60), 20), 
                ForceMode.Impulse);
        }
    }
}
