using System;
using TMPro;
using UnityEngine;

public class EventManagerMeterBridge : MonoBehaviour
{
    public static EventManagerMeterBridge Instance;
    
    public TMP_Text resistancePowerValue;
    public TMP_Text register;
    public TMP_Text l;
    public TMP_Text HunderedMinusL;
    public TMP_Text found;

    public bool isItOn;
    
    

    private void Awake()
    {
        Instance = this;
    }
    
}