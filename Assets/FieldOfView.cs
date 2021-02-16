using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        float fov = 90f;
        int rayCount = 2;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 50f;

        Vector3[] verts = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] tris = new int[3];

        verts[0] = Vector3.zero;
        verts[1] = new Vector3(50, 0);
        verts[2] = new Vector3(0, -50);

        tris[0] = 0;
        tris[1] = 1;
        tris[2] = 2;

        mesh.vertices = verts;
        mesh.uv = uv;
        mesh.triangles = tris;

    }
}
