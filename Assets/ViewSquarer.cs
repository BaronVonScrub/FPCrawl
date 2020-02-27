using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSquarer : MonoBehaviour
{

    public float offset = 30;
    float rat;

    void Update()
    {
        Camera camera = GetComponent<Camera>();

        rat = (float)Screen.width / Screen.height;


        Rect rect = camera.rect;

        rect.width = 0.15f;
        rect.height = 0.15f * rat;


        rect.x = 1.0f - offset/Screen.width - rect.width;
        rect.y = 1.0f - offset/Screen.height - rect.height;

        camera.rect = rect;
    }
}