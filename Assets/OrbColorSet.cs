using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbColorSet : MonoBehaviour
{
    public Color col;
    float newHue;
    float newSat;

    private void Awake()
    {
        //Get newHue from col
        Color.RGBToHSV(col, out newHue, out float newSat, out float vTrash);

        //For each child light, set the colour to col.
        foreach (Light l in GetComponentsInChildren<Light>(true))
        {
            l.enabled = true;
            Color.RGBToHSV(l.color, out float hTrash, out float S, out float V);
            Color newCol = Color.HSVToRGB(newHue, newSat, V);
            l.color = newCol;
        }
    
        //For each child particle system, set the colour to col.
        foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
        {
            ParticleSystem.MainModule m = p.main;

            Color tempCol = m.startColor.color;
            float alph = tempCol.a;
            Color.RGBToHSV(tempCol, out float HTrash, out float S, out float V);
            Color newCol = Color.HSVToRGB(newHue, newSat, V);
            newCol.a = alph;

            m.startColor = newCol;
        }
    }
}
