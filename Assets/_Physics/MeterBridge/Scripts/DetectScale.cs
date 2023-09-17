using System;
using UnityEngine;

public class DetectScale : MonoBehaviour
{
    public Needle needle;
    
    private void OnTriggerEnter(Collider other)
    {
        MeterBridge.Instance.l = other.GetComponent<ScalePower>().scalePower;
        if (MeterBridge.Instance.l > MeterBridge.Instance.finalL)
        {
            MeterBridge.Instance.l = MeterBridge.Instance.finalL;
        }

        MeterBridge.Instance.hundredMinusL = 100 - MeterBridge.Instance.l;
        MeterBridge.Instance.Calculate();
        needle.CalculateRotation(other.GetComponent<ScalePower>().scalePower);
        
    }
}