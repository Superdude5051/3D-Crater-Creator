using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberInput : MonoBehaviour
{
    public float Idensity = 3;
    public float Idiameter = 2;
    public float Ivelocity = 5;
    public float Iangle = 30;
    public float Tdensity = 8;
    public TMP_InputField ImpactorDensity;
    public TMP_InputField ImpactorDiameter;
    public TMP_InputField Velocity;
    public TMP_InputField Angle;
    public TMP_InputField TargetDensity;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ReadImpactorDensity(){
Idensity = float.Parse(ImpactorDensity.text); // assigns the value of the input field to the variable Idensity
Debug.Log("Impactor Density: " + Idensity);
    }
public void ReadImpactorDiameter(){
Idiameter = float.Parse(ImpactorDiameter.text);
Debug.Log("Impactor Diameter: " + Idiameter);
    }
public void ReadVelocity(){
Ivelocity = float.Parse(Velocity.text);

Debug.Log("Velocity: " + Ivelocity);
    }
public void ReadAngle(){
Iangle = float.Parse(Angle.text); 

Debug.Log("Angle: " + Iangle);
    }
public void ReadTargetDensity(){
Tdensity = float.Parse(TargetDensity.text);

Debug.Log("Target Density: " + Tdensity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
