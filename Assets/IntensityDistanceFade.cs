using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityDistanceFade : MonoBehaviour
{
    GameObject player;
    Light myLight;
    Renderer myRenderer;
    Material mat;
    Color baseCol;
    public float lightPersist = 20f;
    public float emmissionPersist = 20f;
    public float lightThreshhold = 2f;
    public float emissionThreshhold = 2f;
    float baseIntensity;
    float x, y, dist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.GetComponent<Light>() != null)
            myLight = gameObject.GetComponent<Light>();
        else
        if (gameObject.GetComponentInChildren<Light>() != null)
            myLight = gameObject.GetComponentInChildren<Light>();
        else
            myLight = null;

        if (myLight!=null)
            baseIntensity = myLight.intensity;

        myRenderer = GetComponent<Renderer>();
        if (myRenderer != null)
        {
            mat = myRenderer.material;
            baseCol = mat.color;
        }
        else
            mat = null;
    }

    // Update is called once per frame
    void Update()
    {
        x = player.transform.position.x;
        y = player.transform.position.z;
        dist = Distance(x, y, transform.position.x, transform.position.z);

        if (myLight != null)
        {
            myLight.intensity = Mathf.Min(baseIntensity, lightPersist * baseIntensity / dist);
            if (myLight.intensity < lightThreshhold) myLight.intensity = 0;
        }

        if (mat != null)
        {
            mat.SetColor("_EmissionColor", baseCol * Mathf.Min(1,emmissionPersist / dist));
            Debug.Log(baseCol);
            Debug.Log(mat.GetColor("_EmissionColor").grayscale);
            if (mat.GetColor("_EmissionColor").grayscale < emissionThreshhold)
                mat.SetColor("_EmissionColor",Color.black);
            mat.SetColor("_Albedo", mat.GetColor("_EmissionColor"));
        }

    }

    float Distance(float x, float y, float xx, float yy)
    {
        return Mathf.Sqrt(Mathf.Pow(x - xx, 2) + Mathf.Pow(y - yy, 2));
    }
}
