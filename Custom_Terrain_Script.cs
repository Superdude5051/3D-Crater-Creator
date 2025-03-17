using UnityEngine;
//using System.collections;
//using System.collections.generic;
public class Custom_Terrain_Script : MonoBehaviour
{
    public int worldX = 10; // Default value, can be changed in Inspector
    public int worldZ = 10; // Default value, can be changed in Inspector

    private Mesh mesh;
    private int[] triangles;
    private Vector3[] vertices;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateMesh();
        UpdateMesh();
    }

    void GenerateMesh()
    {
        // Create vertices
        vertices = new Vector3[(worldX + 1) * (worldZ + 1)];
        for (int z = 0, i = 0; z <= worldZ; z++)
        {
            for (int x = 0; x <= worldX; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        // Create triangles
        triangles = new int[worldX * worldZ * 6];
        int tris = 0;
        int vert = 0;

        for (int z = 0; z < worldZ; z++)
        {
            for (int x = 0; x < worldX; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + worldX + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + worldX + 1;
                triangles[tris + 5] = vert + worldX + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}