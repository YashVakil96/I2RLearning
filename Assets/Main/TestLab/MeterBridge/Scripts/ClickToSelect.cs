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
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.CompareTag("Knob"))
                {
                    power = hitInfo.transform.gameObject.GetComponent<ResistanceKnobPower>().power;
                    ActionsBridge.ResistanceKnobClicked();
                }
            }
            else
            {
                Debug.Log("No Hit");
            }
        }
    }

    public void CheckPower()
    {
        Debug.Log(power);
        EventManagerMeterBridge.Instance.resistancePowerValue.text = power.ToString();
    }
}