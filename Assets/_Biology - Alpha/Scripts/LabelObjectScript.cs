using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LabelObjectScript : MonoBehaviour
{
    // public GameObject uiPointPrefab;
    public GameObject uiPointPrefab;
    public List<UIObjectNameScript> uiPointsList = new List<UIObjectNameScript>();
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLabelOnSelectedPoint();
        }
    }

    private void CreateLabelOnSelectedPoint()
    {
        var obj = ObjectSelector.Instance.SelectObject();
        if (obj == null)
        {
            return;
        }

        if (uiPointsList.Any(item => item.gameObject.name == "UI " + obj.selectedObject.name))
        {
            return;
        }
        
        var ui = Instantiate(uiPointPrefab, obj.selectedPoint, Quaternion.identity);
        var uiScript = ui.GetComponent<UIObjectNameScript>();
        
        ui.name = "UI " + obj.selectedObject.name;
        uiScript.objectNameText.text = obj.selectedObject.name;
        
        uiPointsList.Add(uiScript);
    }

    private void OnDisable()
    {
        if (uiPointsList == null)
        {
            return;
        }
        foreach (var item in uiPointsList)
        {
            Destroy(item.gameObject);
        }
        uiPointsList.Clear();
    }
}
