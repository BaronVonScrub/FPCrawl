using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkTracker : MonoBehaviour
{
    public bool walking = false;
    public Vector3 goalPos;
    public Vector3 currPos;
    public float moveSpeed = 3;

    private void Start()
    {
        goalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currPos = transform.position;
        if (goalPos - currPos != Vector3.zero)
        {
            Vector3 moveAmount = Mathf.Min(Vector3.Magnitude(goalPos-currPos),Time.deltaTime * moveSpeed) * Vector3.Normalize(goalPos - currPos);
            transform.position += moveAmount;
            walking = true;
        }
        else
            walking = false;

    }
}
