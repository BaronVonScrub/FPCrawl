using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    public int sortOrder=0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingOrder = sortOrder;
    }
}
