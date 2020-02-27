using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraUniqueLighting : MonoBehaviour
{

    List<Light> switchLights;

    private void Start()
    {
        switchLights = new List<Light>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("OverheadOnly"))
            switchLights.Add(obj.GetComponent<Light>());
    }

    void OnPreCull()
    {
        foreach (Light l in switchLights)
            l.enabled = true;
    }

    void OnPostRender()
    {
        foreach (Light l in switchLights)
            l.enabled = false;
    }
}