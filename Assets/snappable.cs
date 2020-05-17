using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snappable : MonoBehaviour
{
    public float gridSize;
    public bool snapOn = true;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Snap()
    {
        if (snapOn == true)
        {
            float xx = Mathf.Round((transform.position.x-gridSize*0.5f) / gridSize) * gridSize+0.5f*gridSize;
            float zz = Mathf.Round((transform.position.z-gridSize*0.5f) / gridSize) * gridSize+0.5f*gridSize;

            transform.position = new Vector3(xx, transform.position.y, zz);
        }
    }
}
