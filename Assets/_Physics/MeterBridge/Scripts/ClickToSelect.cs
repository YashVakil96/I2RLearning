using System;
using UnityEngine;

public class ClickToSelect : MonoBehaviour
{
    private void OnEnable()
    {
        ActionsBridge.ResistanceKnobClicked += CheckPower;
    }

    private void OnDisable()
    {
        ActionsBridge.ResistanceKnobClicked -= CheckPower;
    }

    public int power;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.gameObject.CompareTag("Knob"))
                {
                    power = hitInfo.transform.gameObject.GetComponent<ResistanceKnobPower>().power;
                    ActionsBridge.ResistanceKnobClicked();
                }
            }
        }
    }

    public void CheckPower()
    {
        EventManagerMeterBridge.Instance.resistancePowerValue.text = power.ToString();
        MeterBridge.Instance.resistanceBoxPower = power;
        EventManagerMeterBridge.Instance.isItOn = true;
    }
}