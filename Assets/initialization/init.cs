using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class init : MonoBehaviour
{
    public UnityEvent ev;
    void Awake()
    {
        ev.Invoke();
    }
}
