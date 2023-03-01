using System;
using TMPro;
using UnityEngine;

public class EventManagerMeterBridge : MonoBehaviour
{
    public static EventManagerMeterBridge Instance;
    
    public TMP_Text resistancePowerValue;

    private void Awake()
    {
        Instance = this;
    }
    
}