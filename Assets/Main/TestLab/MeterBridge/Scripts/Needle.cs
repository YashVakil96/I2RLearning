using System;
using UnityEngine;

// [ExecuteInEditMode]

public class Needle : MonoBehaviour
{
    [Range(-45, 45)] public float rotation;
    public Vector3 useRotation;

    private void Update()
    {
        CalculateRotation();
    }

    void CalculateRotation()
    {
        //-90 0
        // 90 1
        var newR = UnitIntervalRange(0, 1, -45, 45, 1);
        transform.rotation = Quaternion.Euler(useRotation.x, useRotation.y, rotation);
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