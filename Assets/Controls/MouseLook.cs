using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float X;
    private float Y;
    private GameObject myParent;
    public float xDir;
    public float Sensitivity;
    public float timer;
    public float timeToRebound = 3;
    public float reboundStrength = 1.1f;

    void Awake()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y;
    }

    private void Start()
    {
        myParent = transform.parent.gameObject;
    }

    public void Update()
    {
        const float MIN_Y = -35.0f;
        const float MAX_Y = 35.0f;

        xDir = myParent.transform.rotation.eulerAngles.y;

        float xShift = Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        X += xShift;
        Y -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);

        Y = Mathf.Clamp(Y, MIN_Y, MAX_Y);
        X = Mathf.Clamp(X, -45f, 45f);

        if (xShift == 0)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
        }
        else
            timer = timeToRebound;

        if (timer <= 0)
        {
            X = X / reboundStrength;
            Y = Y / reboundStrength;

            if (Mathf.Abs(X) < .05f)
                X = 0f;
            if (Mathf.Abs(Y) < .05f)
                Y = 0f;
        }

        transform.rotation = Quaternion.Euler(Y,xDir + X, 0.0f);
    }
}
