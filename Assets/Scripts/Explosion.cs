using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    Material exploidMaterial;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Exploid();
        }
    }

    IEnumerator enumerator(Transform transform)
    {
        yield return new WaitForSeconds(2);
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(40,0,40);
            child.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.forward*10);
        }
    }
    
    void Exploid()
    {
        GetComponent<Animator>().enabled = false;
        
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            child.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0, 1000), Random.Range(-400, 200), 100),
                ForceMode.Impulse);
        }

        StartCoroutine("enumerator", transform);
    }
}
