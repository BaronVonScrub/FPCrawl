using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TorchControl : MonoBehaviour
{
    public void TorchUp()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Light light = player.transform.GetChild(3).GetComponent<Light>();
        light.intensity += 1;
    }

    public void TorchDown()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Light light = player.transform.GetChild(3).GetComponent<Light>();
        light.intensity -= 1;
    }


}
