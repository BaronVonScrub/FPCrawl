using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkTracker : MonoBehaviour
{
    private snappable snapper;
    public bool walking = false;
    public Vector3 goalPos;
    public Vector3 currPos;
    public float moveSpeed = 20;

    private void Start()
    {
        Debug.Log("INITIALIZING");
        snapper = gameObject.GetComponent<snappable>();
        snapper.Snap();
        goalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        goalPos = new Vector3(Mathf.Round(goalPos.x), goalPos.y, Mathf.Round(goalPos.z));
        currPos = transform.position;
        if (goalPos - currPos != Vector3.zero)
        {
            snapper.snapOn = false;
            Vector3 moveAmount = Mathf.Min(Vector3.Magnitude(goalPos - currPos), Time.deltaTime * moveSpeed) * Vector3.Normalize(goalPos - currPos);
            transform.position += moveAmount;
            walking = true;
        }
        else
        {
            walking = false;
            snapper.snapOn = true;
        }

    }
}