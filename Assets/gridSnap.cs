using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridSnap : MonoBehaviour
{ 
    public float gridSize = 6.0f;
    private List<snappable> snapList;
    void Start()
    {
        snapList = new List<snappable>();
        foreach (snappable com in GameObject.FindObjectsOfType<snappable>())
        {
            snapList.Add(com);
            com.gridSize = gridSize;
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach (snappable com in snapList)
        {
            com.Snap();
        }
    }
}
