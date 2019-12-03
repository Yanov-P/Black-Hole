using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotation : MonoBehaviour
{
    public float _rotateSpeed = 0.125f;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time*_rotateSpeed);
    }
}
