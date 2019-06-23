using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    public int xSize = 20;
    public int zSize = 20;
    float noise;
    float gain;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        // CreateTriangle();
        CreateShape();
        UpdateMesh();
    }

    void CreateTriangle()
    {
        vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1)
        };

        triangles = new int[]
        {
            0, 1, 2, 1, 3, 2
        };
    }

    void CreateShape()
    {
        gain = Mathf.Sqrt(xSize * zSize) / 10;
        noise = 1 / Mathf.Sqrt(xSize * zSize);
        Debug.Log(noise + " " + gain);

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                float y = Mathf.PerlinNoise(x * .1f, z * .1f) * 3f;
                vertices[i] = new Vector3(x, y, z);
            }
        }

        triangles = new int[xSize * zSize * 6];
        for (int iTri = 0, iVert = 0, z = 0; z < zSize; z++, iVert++)
        {
            for (int x = 0; x < xSize; x++, iTri+=6, iVert++)
            {
                triangles[iTri + 0] = iVert + 0;
                triangles[iTri + 1] = iVert + xSize + 1;
                triangles[iTri + 2] = iVert + 1;
                triangles[iTri + 3] = iVert + 1;
                triangles[iTri + 4] = iVert + xSize + 1;
                triangles[iTri + 5] = iVert + xSize + 2;
            }
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices  = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
