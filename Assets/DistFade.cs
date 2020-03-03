using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistFade : MonoBehaviour
{
    GameObject player;
    List<Light> lights;
    List<Renderer> rend;
    List<Material> mat;
    List<Color> rendBaseCol;
    public float startFade = 36;
    public float endFade = 46;
    private int i;
    List<float> baseIntensity;
    float x, y, dist;
    List<ParticleSystem> systems;
    ParticleSystem.Particle[] parts;
    List<float> partBaseAlph;
    List<Color> partBaseCol;
    private float slope;

    // Start is called before the first frame update
    void Start()
    {
        //Initialization
        player = GameObject.FindGameObjectWithTag("Player");
        slope = distSlope(startFade, endFade);

        //Light list initialization
        lights = new List<Light>();
        baseIntensity = new List<float>();

        //Emission list initialization
        rend = new List<Renderer>();
        mat = new List<Material>();

        //Particle list initialization
        parts = new ParticleSystem.Particle[1000];
        systems = new List<ParticleSystem>();
        partBaseCol = new List<Color>();
        partBaseAlph = new List<float>();

        //List lights
        foreach (Light l in GetComponents<Light>())
        {
            lights.Add(l);
            baseIntensity.Add(l.intensity);
        }
        foreach (Light l in GetComponentsInChildren<Light>())
        {
            lights.Add(l);
            baseIntensity.Add(l.intensity);
        }

        //List renderers for materials
        foreach (Renderer r in GetComponents<Renderer>())
        {
            mat.Add(r.material);
            rendBaseCol.Add(r.material.color);
        }
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            if (r.material.HasProperty("Color"))
            {
                mat.Add(r.material);
                rendBaseCol.Add(r.material.color);
            }
        }

        //List particle systems
        foreach (ParticleSystem partSys in GetComponents<ParticleSystem>())
        {
            systems.Add(partSys);
            partBaseCol.Add(partSys.main.startColor.color);
            partBaseAlph.Add((partSys.main.startColor.color.a));
        }
        foreach (ParticleSystem partSys in GetComponentsInChildren<ParticleSystem>())
        {
            systems.Add(partSys);
            partBaseCol.Add(partSys.main.startColor.color);
            partBaseAlph.Add((partSys.main.startColor.color.a));
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = player.transform.position.x;
        y = player.transform.position.z;

        i = 0;
        foreach (Light l in lights)
        {
            dist = Distance(x, y, l.transform.parent.transform.position.x, l.transform.parent.transform.position.z);
            float rat = (dist - endFade) * slope;
            rat = Mathf.Clamp(rat, 0, 1);

            l.intensity = baseIntensity[i] * rat;
        }

        i = 0;
        foreach (Renderer r in rend)
        {
            dist = Distance(x, y, r.transform.parent.transform.position.x, r.transform.parent.transform.position.z);
            float rat = (dist - endFade) * slope;
            rat = Mathf.Clamp(rat, 0, 1);

            mat[i].SetColor("_EmissionColor", rendBaseCol[i] * rat);
            mat[i].SetColor("_Albedo", mat[i].GetColor("_EmissionColor"));
        }



        //Part System Fade

        i = 0;
            foreach (ParticleSystem m in systems)
            {
                ParticleSystem.MainModule mm = m.main;
                dist = Distance(x, y, m.transform.parent.transform.position.x, m.transform.parent.transform.position.z);
                float rat = (dist - endFade) * slope;
                rat = Mathf.Clamp(rat, 0, 1);

                float tempAlph = partBaseAlph[i] * rat;
                Color tempCol = partBaseCol[i];
                tempCol.a = tempAlph;

                mm.startColor = tempCol;

                int numParticlesAlive = m.GetParticles(parts);
                ParticleSystem.Particle[] partsNew = new ParticleSystem.Particle[numParticlesAlive];
                for (int j = 0; j < numParticlesAlive; j++)
                {
                    partsNew[j] = parts[j];
                    partsNew[j].startColor = tempCol;

                    m.SetParticles(partsNew);
                }
                i++;
            }

    }

    float Distance(float x, float y, float xx, float yy)
    {
        return Mathf.Sqrt(Mathf.Pow(x - xx, 2) + Mathf.Pow(y - yy, 2));
    }

    float distSlope(float start, float end)
    {
        return -1 / (end - start);
    }
}
