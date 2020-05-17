using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material material = gameObject.GetComponent<Renderer>().material;
        material.SetFloat("_GridSpacing", FindObjectOfType<gridSnap>().gridSize);
    }
}
