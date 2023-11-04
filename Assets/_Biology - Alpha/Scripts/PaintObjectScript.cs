using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PaintObjectScript : MonoBehaviour
{
    public List<GameObject> coloredObj = new List<GameObject>();
    public Color c1;
    public Color c2;
    public Color c3;
    public Color c4;
    public Color currentSelectedObjectColor;
    public List<Material> m_Materials = new List<Material>();

    public GameObject paintPanel;
    private void Update()
    {
        if (GameManager.Instance.currentSelectedPage == UIPages.Paint)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectObjectWithMouse();
            }    
        }
    }

    private void OnEnable()
    {
        paintPanel.SetActive(true);
        ChangeColor(1);
    }

    private void OnDisable()
    {
        paintPanel.SetActive(false);
        DeSelectObject();
    }

    public void ChangeColor(int index)
    {
        switch (index)
        {
            case 1 :
                currentSelectedObjectColor = c1;
                break;
            case 2:
                currentSelectedObjectColor = c2;
                break;
            case 3:
                currentSelectedObjectColor = c3;
                break;
            case 4:
                currentSelectedObjectColor = c4;
                break;
        }    
    }

    private void SelectObjectWithMouse()
    {
        var a = ObjectSelector.Instance.SelectObject();
        if (a == null)
        {
            return;
        }

        // if (coloredObj.Contains(a.selectedObject))
        // {
        //     return;
        // }
        
        // coloredObj.Add(a.selectedObject);
        m_Materials.Clear();
        m_Materials.AddRange(a.selectedObject.GetComponent<MeshRenderer>().materials.ToList());
        foreach (var mat in m_Materials)
        {
            mat.color = currentSelectedObjectColor;
        }
    }

    private void DeSelectObject()
    {
        foreach (var mat in m_Materials)
        {
            mat.color = new Color(0.91f, 0.91f, 0.91f);
        }

        coloredObj.Clear();
        m_Materials.Clear();
    }
}
