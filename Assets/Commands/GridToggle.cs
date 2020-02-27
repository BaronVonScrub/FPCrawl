using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridToggle : MonoBehaviour
{
    public void Toggle()
    {
        GameObject floor = GameObject.FindGameObjectWithTag("Floor");
        Renderer renderer = floor.GetComponent<Renderer>();
        Material material = renderer.material;

        if (material.shader != Shader.Find("Custom/GroundShader"))
            material.shader = Shader.Find("Custom/GroundShader");
        else
            material.shader = Shader.Find("Custom/GridShader");
    }
}
