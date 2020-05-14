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

        if (material.GetFloat("_GridThickness") == 0.2f)
            material.SetFloat("_GridThickness", 0.0f);
        else
            material.SetFloat("_GridThickness", 0.2f);
    }
}
