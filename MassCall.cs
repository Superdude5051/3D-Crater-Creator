using UnityEngine;

public class MassCall : MonoBehaviour
{
    public GroundRepainter GroundRepainter1;
    public GroundRepainter GroundRepainter2;
    public GroundRepainter GroundRepainter3;
    public GroundRepainter GroundRepainter4;
    public GroundRepainter GroundRepainter5;
    public GroundRepainter GroundRepainter6;
    public GroundRepainter groundRepainter7;
    public GroundRepainter groundRepainter8;
    public GroundRepainter groundRepainter9;
    public Cratercreator1 CrateringSurface1;
    public Cratercreator1 CrateringSurface2;
    public Cratercreator1 CrateringSurface3;
    public Cratercreator1 CrateringSurface4;
    public Cratercreator1 CrateringSurface5;
    public Cratercreator1 CrateringSurface6;
    public Cratercreator1 CrateringSurface7;
    public Cratercreator1 CrateringSurface8;
    public Cratercreator1 CrateringSurface9;

    // Method to call all RecalculateCrater methods
    public void RecalculateAll()
    {
        if (GroundRepainter1 != null)
            GroundRepainter1.RecalculateCrater();

        if (GroundRepainter2 != null)
            GroundRepainter2.RecalculateCrater();

        if (GroundRepainter3 != null)
            GroundRepainter3.RecalculateCrater();

        if (GroundRepainter4 != null)
            GroundRepainter4.RecalculateCrater();

        if (GroundRepainter5 != null)
            GroundRepainter5.RecalculateCrater();

        if (GroundRepainter6 != null)
            GroundRepainter6.RecalculateCrater();

        if (groundRepainter7 != null)
            groundRepainter7.RecalculateCrater();

        if (groundRepainter8 != null)
            groundRepainter8.RecalculateCrater();

        if (groundRepainter9 != null)
            groundRepainter9.RecalculateCrater();

        if (CrateringSurface1 != null)
            CrateringSurface1.RecalculateCrater();

        if (CrateringSurface2 != null)
            CrateringSurface2.RecalculateCrater();

        if (CrateringSurface3 != null)
            CrateringSurface3.RecalculateCrater();

        if (CrateringSurface4 != null)
            CrateringSurface4.RecalculateCrater();

        if (CrateringSurface5 != null)
            CrateringSurface5.RecalculateCrater();

        if (CrateringSurface6 != null)
            CrateringSurface6.RecalculateCrater();

        if (CrateringSurface7 != null)
            CrateringSurface7.RecalculateCrater();

        if (CrateringSurface8 != null)
            CrateringSurface8.RecalculateCrater();

        if (CrateringSurface9 != null)
            CrateringSurface9.RecalculateCrater();

        Debug.Log("Recalculating all craters");
    }
}
