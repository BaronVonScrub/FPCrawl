using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFitToMap : MonoBehaviour
{
    public GameObject map, grid;

    // Start is called before the first frame update
    void Start()
    {
        //Get the size of the map.
        Mesh mesh = map.GetComponent<MeshFilter>().mesh;
        float w = mesh.bounds.size.x;
        float h = mesh.bounds.size.z;
        
        //Scale the grid object to the size of the map (/10 as it is a plane)
        grid.transform.localScale = new Vector3(w/10, 1, h/10);
        //Scale 
        grid.GetComponent<Renderer>().material.mainTextureScale = new Vector2(w/6f, h/6f);
    }
}
