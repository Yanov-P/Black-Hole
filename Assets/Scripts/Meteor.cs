using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Meteor : Enemy
{
    public delegate void GameDelegate(int score);
    public static event GameDelegate gainScore;
    public static event GameDelegate loseScore;

    int _radius;
    int countOfScore;

    bool _isBroken = false;
    bool _wasStarted = false;

    public enum Type
    {
        circle,
        simple,
        up
    }
    public Type _typeOfMeteor;


    Dictionary<GameObject, Vector3> _particlesStates = new Dictionary<GameObject, Vector3>();


    float speed = (Mathf.PI * 2) / 40.0f;
    float currentAngle = 0;

    private void Start()
    {
        GetRandomRadius();
        StartSet();
    }


   
    public void Update()
    {
        if (_isBroken)
            SimpleMove();
        else
            Move();
    }
    void StartSet()
    {
        foreach (Transform particle in transform.GetChild(0).transform)
        {
            var vector = new Vector3(particle.gameObject.transform.localPosition.x,
                particle.gameObject.transform.localPosition.y, particle.gameObject.transform.localPosition.z);
            _particlesStates.Add(particle.gameObject, vector);
        }
        var random= Random.Range(3, 5);
        transform.localScale = new Vector3(random, random, random);
        _maxHealth = transform.localScale.x;
        _currentHealth = _maxHealth;
        _wasStarted = true;
        countOfScore = (int)_maxHealth;
    }

    void GetRandomRadius()
    {
        int k = Random.Range(1, 3);
        if (k == 1)
            _radius = Random.Range(640, 645);
        else _radius = Random.Range(655, 660);
    }

    private void Move()
    {
        if (_typeOfMeteor == Type.simple)
        {
            transform.eulerAngles += new Vector3(0, 1, 0);
            transform.position += new Vector3(0, 0, 1.5f);
        }

        if (_typeOfMeteor == Type.up)
        {
            transform.eulerAngles += new Vector3(0, 1, 0);
            transform.position += new Vector3(0, 0, 1.5f);
        }
        if (_typeOfMeteor == Type.circle)
        {
            currentAngle -= Time.deltaTime * speed;
            var x = _radius * Mathf.Cos(currentAngle);
            var z = _radius * Mathf.Sin(currentAngle);
            transform.position = new Vector3(x, 0, z);
        }
        if (transform.position.z > 40)
        {
            gameObject.SetActive(false);
        }
    }
    
    void SimpleMove()
    {
        transform.position += new Vector3(0, 0, 1.5f);
        if (transform.position.z > 40)
        {
            gameObject.SetActive(false);
        }
    }
    public override void TakeDamage(float damage)
    {
        (this as Character).TakeDamage(damage);
        if(_currentHealth <= 0)
        {
            MeteorDeath();
        }
    }

    void MeteorDeath()
    {
        _isBroken = true; 
        gainScore(countOfScore);
        gameObject.GetComponent<MeshCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        FullDestroy();
    }

    private void OnEnable() 
    {
        if (_wasStarted)
        {
            MeteorReset();
        }
    }

    void MeteorReset()
    {
        var scale = Random.Range(3, 5);
        transform.localScale = new Vector3(scale, scale, scale);
        _maxHealth = transform.localScale.x;
        GetComponent<Meteor>().enabled = true;
        _isBroken = false;
        _currentHealth = _maxHealth;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        ResetParticles();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ICartridge>() != null)
        {
            collision.gameObject.GetComponent<ICartridge>().MakeDamage(this);
        }
        if (collision.collider.gameObject.tag == "Player")
        {
            loseScore(10);
        }
    }
}
