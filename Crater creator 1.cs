using System;
using UnityEngine;
using UnityEngine.UI;

public class Cratercreator1 : MonoBehaviour
{
    public GameObject Canvas; // Reference to the Canvas GameObject
    public NumberInput NumberInput; // Reference to the NumberInput component

    public Text text;
    public float Idensity = 3;
    public float Tdensity = 2; 
    public float L = 2; // diameter of the impactor after entering the atmosphere
    public float Vi = 5; // Impactor Velocity at the time of impact
    public float Ge = 9.8f;
    public float Angle = 30;
    // float StartAltitude = 8;
    double Radians;

    float DLS; //diameter of final crater, used to make the crater
    float TCD; //transient crater diameter, not used to make the 3D crater
    public static float DFC; // Make DFC public and static
    float HFR; //rim height
    float CraterDepth;
    //float YeildStrength = 1.0f;
    public Color craterColor = Color.gray; // New variable for crater color
    private Mesh mesh;
    private Vector3[] vertices, modifiedVerts; //these get the vertices and modified verticies of the mesh
    private Color[] colors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure that the NumberInput component is properly assigned
        if (NumberInput == null)
        {
            NumberInput = Canvas.GetComponentInChildren<NumberInput>();
        }

        // Ensure that the Text component is properly assigned
        if (text == null)
        {
            text = Canvas.GetComponentInChildren<Text>();
        }

        if (NumberInput != null && text != null)
        {
            RecalculateCrater();
            mesh = GetComponentInChildren<MeshFilter>().mesh;
            vertices = mesh.vertices;
            modifiedVerts = new Vector3[vertices.Length];
            colors = new Color[vertices.Length];

            // Initialize colors to white
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.white;
            }

            mesh.colors = colors; // Apply initial colors to the mesh
        }
        else
        {
            Debug.LogError("NumberInput or Text component is not assigned or found.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                CreateCrater(hit.point);
            }
        }
    }

    void CreateCrater(Vector3 craterPosition)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = transform.TransformPoint(vertices[i]);
            float distance = Vector3.Distance(vertex, craterPosition);
            if (distance < DFC)
            {
                float deformation = Mathf.Lerp(CraterDepth, 0, distance / DFC);
                vertex.y -= deformation;
                colors[i] = craterColor; // Change color for crater
            }
            else if (distance < DFC * 1.2f) // Slightly beyond the crater radius for the rim
            {
                float rimDeformation = Mathf.Lerp(0, HFR, (distance - DFC) / (DFC * 0.2f));
                vertex.y += rimDeformation;
                colors[i] = craterColor; // Change color for rim
            }
            else
            {
                colors[i] = Color.white; // Default color for unaffected terrain
            }
            modifiedVerts[i] = transform.InverseTransformPoint(vertex);
        }
        mesh.vertices = modifiedVerts;
        mesh.colors = colors; // Apply colors to the mesh
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    public void RecalculateCrater()
    {
        if (NumberInput == null)
        {
            Debug.LogError("NumberInput is not assigned.");
            return;
        }

        Radians = NumberInput.Iangle * Math.PI / 180;
        DLS = NumberInput.Idiameter * Mathf.Sin((float)Radians) * Mathf.Sqrt(NumberInput.Idensity / 2);
        L = NumberInput.Idiameter * Mathf.Sqrt(1 + Mathf.Pow(16 / DLS, 2)); // Set L to the diameter of the impactor
        Vi = NumberInput.Ivelocity * Mathf.Exp((3 * 1 * 2 * 8) / (4 * NumberInput.Idensity * NumberInput.Idiameter * Mathf.Sin(NumberInput.Iangle))); // Calculate Vi        
        TCD = 1.161f * Mathf.Pow((NumberInput.Idensity / NumberInput.Tdensity), 1.0f / 3.0f) * Mathf.Pow(L, 0.78f) * Mathf.Pow(Vi, 0.44f) * Mathf.Pow(Ge, -0.22f) * Mathf.Pow(Mathf.Sin((float)Radians), 0.33f);
        DFC = TCD * 1.25f;
        HFR = 0.07f * Mathf.Pow(TCD, 4) / Mathf.Pow(DFC, 3);
        CraterDepth = 0.4f * Mathf.Pow(DFC, 0.3f);

        // Normalize values to ensure realistic appearance
        DFC = Mathf.Clamp(DFC, 1f, 100f);
        HFR = Mathf.Clamp(HFR, 0.1f, 10f);
        CraterDepth = Mathf.Clamp(CraterDepth, 0.1f, 10f);

        if (text != null)
        {
            text.text = "Crater Diameter: " + DFC + " Rim Height: " + HFR + " Crater Depth: " + CraterDepth;
        }

        Debug.Log("Recalculated Crater: DFC: " + DFC + " HFR: " + HFR + " Crater Depth: " + CraterDepth);
    }
}
