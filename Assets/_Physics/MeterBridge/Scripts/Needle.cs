using System;
using UnityEngine;

[ExecuteInEditMode]

public class Needle : MonoBehaviour
{
    [Range(-45, 45)] public float rotation;
    public Vector3 useRotation;

    public void CalculateRotation(int scalePower)
    {
        //-90 0
        // 90 1
        var newR = UnitIntervalRange(0, 1, -45, 45, 1);
        transform.rotation = Quaternion.Euler(useRotation.x, useRotation.y, RotateNeedle(scalePower));
    }

    public float RotateNeedle(int scalePower)
    {
        var l = MeterBridge.Instance.finalL;
        
        var rot = (float)scalePower -l;

        float newRot = (float) rot;
        
        /*
         * 100
         * 
         */
        return newRot;
    }

    float UnitIntervalRange(float stageStartRange, float stageFinishRange, float newStartRange, float newFinishRange,
        float floatingValue)
    {
        float outRange = Mathf.Abs(newFinishRange - newStartRange);
        float inRange = Mathf.Abs(stageFinishRange - stageStartRange);
        float range = (outRange / inRange);
        return (newStartRange + (range * (floatingValue - stageStartRange)));
    }
}