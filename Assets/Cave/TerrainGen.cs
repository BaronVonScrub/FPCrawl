using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainGen : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    public float noiseDepth = 2.5f;
    public int octaves = 5;
    public float persistence = 0.5f;
    public float lacunarity = 0.5f;
    public float xScale = 1f;
    public float zScale = 1f;
    public float xOffset = 0.1f;
    public float zOffset = 0.1f;

    public int xSize = 20;
    public int zSize = 20;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshFilter>().mesh.name = gameObject.name;

        CreateShape();
        UpdateMesh();
        
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = noiseDepth * layeredPerlin(x,z,octaves,persistence,lacunarity,xOffset,zOffset);
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        uvs = new Vector2[vertices.Length];


        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        mesh.RecalculateNormals();
    }

    float layeredPerlin(float x, float y, int octaves, float persistence, float lacunarity, float xOffset, float yOffset)
    {
        float value = 0;
        for (int i = 0; i < octaves; i++)
        {
            value += Mathf.Pow(persistence, i) * Mathf.PerlinNoise(((x + Mathf.Pow(xOffset, i))/xScale) / Mathf.Pow(lacunarity, i), ((y + Mathf.Pow(yOffset, i))/zScale) / Mathf.Pow(lacunarity, i));
        }
        return value;
    }
}
