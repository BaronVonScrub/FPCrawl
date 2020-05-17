using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    GameObject player;
    turnTracker turnt;
    walkTracker walkt;

    public void TurnLeft()
    {
        if (turnt.turning == false && walkt.walking == false)
            turnt.goalX -= 90;
    }

    public void TurnRight()
    {
        if (turnt.turning == false && walkt.walking == false)
            turnt.goalX += 90;
    }

    public void MoveLeft()
    {
        if (turnt.turning == false && walkt.walking == false)
            walkt.goalPos += player.transform.rotation * new Vector3(-moveSpeed, 0, 0);
    }

    public void MoveRight()
    {
        if (turnt.turning == false && walkt.walking == false)
            walkt.goalPos += player.transform.rotation * new Vector3(moveSpeed, 0, 0);
    }

    public void MoveForward()
    {
        if (turnt.turning == false && walkt.walking == false)
            walkt.goalPos += player.transform.rotation * new Vector3(0, 0, moveSpeed);
    }

    public void MoveBackward()
    {
        if (turnt.turning == false && walkt.walking == false)
            walkt.goalPos += player.transform.rotation * new Vector3(0, 0,-moveSpeed);
    }

    public void Init()
    {
        moveSpeed = FindObjectOfType<gridSnap>().gridSize;
        player = GameObject.FindGameObjectWithTag("Player");
        walkt = player.GetComponent<walkTracker>();
        turnt = player.GetComponent<turnTracker>();
    }
}
