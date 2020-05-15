using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraUniqueShader : MonoBehaviour
{

    Material mat;
    public bool gridOn = true;
    

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Floor");
        mat = obj.GetComponent<Renderer>().material;
    }

    void OnPreCull()
    {
        if (mat.shader == Shader.Find("Custom/GroundShader"))
            gridOn = false;
        else
            gridOn = true;

        mat.shader = Shader.Find("Custom/GroundShader");
    }

    void OnPostRender()
    {
        if (gridOn == true)
            mat.shader = Shader.Find("Custom/GridShader");
    }
}