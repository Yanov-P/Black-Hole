using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSwitcher : MonoBehaviour
{
    public List<Material> listOfMaterials;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CancelInvoke();
            InvokeRepeating("OffShape", 0, 0.01f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            CancelInvoke();
            InvokeRepeating("OnShape", 0, 0.01f);
        }
    }

    void OffShape()
    {
        foreach (Material material in listOfMaterials)
        {
            
            if (material.GetFloat("_invis") > 1)
            {
                CancelInvoke();
            }

            material.SetFloat("_invis", material.GetFloat("_invis") + 0.01f);

        }
    }
    void OnShape()
    {
        foreach (Material material in listOfMaterials)
        {

            if (material.GetFloat("_invis") < -1)
            {
                CancelInvoke();
            }

            material.SetFloat("_invis", material.GetFloat("_invis") - 0.01f);

        }
    }
}
