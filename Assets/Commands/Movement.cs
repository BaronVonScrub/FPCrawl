using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public float moveSpeed =3;

    public void TurnLeft()
    {
        GameObject player = GameObject.FindWithTag("Player");
        turnTracker tracker = player.GetComponent<turnTracker>();
        if (tracker.turning == false)
            tracker.goalX -= 90;
    }

    public void TurnRight()
    {
        GameObject player = GameObject.FindWithTag("Player");
        turnTracker tracker = player.GetComponent<turnTracker>();
        if (tracker.turning == false)
            tracker.goalX += 90;
    }

    public void MoveLeft()
    {
        GameObject player = GameObject.FindWithTag("Player");
        walkTracker tracker = player.GetComponent<walkTracker>();
        if (tracker.walking == false)
            tracker.goalPos += player.transform.rotation * new Vector3(-moveSpeed, 0, 0);
    }

    public void MoveRight()
    {
        GameObject player = GameObject.FindWithTag("Player");
        walkTracker tracker = player.GetComponent<walkTracker>();
        if (tracker.walking == false)
            tracker.goalPos += player.transform.rotation * new Vector3(moveSpeed, 0, 0);
    }

    public void MoveForward()
    {
        GameObject player = GameObject.FindWithTag("Player");
        walkTracker tracker = player.GetComponent<walkTracker>();
        if (tracker.walking == false)
            tracker.goalPos += player.transform.rotation * new Vector3(0, 0, moveSpeed);
    }

    public void MoveBackward()
    {
        GameObject player = GameObject.FindWithTag("Player");
        walkTracker tracker = player.GetComponent<walkTracker>();
        if (tracker.walking == false)
            tracker.goalPos += player.transform.rotation * new Vector3(0, 0,-moveSpeed);
    }
}
