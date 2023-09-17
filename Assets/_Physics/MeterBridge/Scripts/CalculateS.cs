using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateS : MonoBehaviour
{
    public TMP_Text valueR;
    public TMP_Text valueL;
    public TMP_Text value100MinusL;
    public TMP_Text answer;

    public void Calculate()
    {
        valueR.text = EventManagerMeterBridge.Instance.resistancePowerValue.text;
        
        valueL.text = MeterBridge.Instance.finalL.ToString();
        value100MinusL.text = MeterBridge.Instance.hundredMinusL.ToString(); 
        
        answer.text = MeterBridge.Instance.finalRes.ToString();
    }
}