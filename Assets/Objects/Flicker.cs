using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    Light myLight;
    //public Light overLight;
    Color baseColor;
    public float flickerPercent=30f;
    public float hueflickerAmount=.3f;
    public float valflickerAmount = .4f;
    public float huePulseSpeed = 30;
    public float huePulseAmount = 0.01f;
    public float valPulseSpeed = 30;
    public float valPulseAmount = 0.01f;
    Color HSVColor;
    float hueShift, satShift, valShift, baseHue, baseSat, baseVal,hueFlickerShift,valFlickerShift;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        baseColor = myLight.color;
        Color.RGBToHSV(baseColor, out baseHue, out baseSat, out baseVal);
        satShift = 0;
        valShift = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < flickerPercent /100)
            hueFlickerShift = Random.Range(-hueflickerAmount,hueflickerAmount);
        else
            hueFlickerShift = 0;

        if (Random.value < flickerPercent/100)
            valFlickerShift = Random.Range(-valflickerAmount, valflickerAmount);
        else
            valFlickerShift = 0;


        hueShift = huePulseAmount*Mathf.Sin(hueFlickerShift+Time.time * huePulseSpeed);
        valShift = valPulseAmount * Mathf.Sin(valFlickerShift + Time.time * valPulseSpeed);

        myLight.color=Color.HSVToRGB(baseHue+hueShift, baseSat + satShift, baseVal + valShift);

       // overLight.color= Color.HSVToRGB(baseHue + hueShift, baseSat + satShift, baseVal + valShift);
    }
}
