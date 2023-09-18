using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class SelectObjectScript : MonoBehaviour
{
    private GameObject selectedObj = null;
    public Color SelectedObjectColor = Color.yellow;
    public Material selectedObjMat;


    private List<Material> m_Materials = new List<Material>();
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectObjectWithMouse();
        }
    }

    private void OnDisable()
    {
        DeSelectObject();
    }

    private void SelectObjectWithMouse()
    {
        var a = ObjectSelector.Instance.SelectObject();
        if (a == null)
        {
            return;
        }
        if (selectedObj != null)
        {
            DeSelectObject();
        }
        selectedObj = a.selectedObject;
        m_Materials = selectedObj.GetComponent<MeshRenderer>().materials.ToList();
        m_Materials.Add(selectedObjMat);
        selectedObj.GetComponent<MeshRenderer>().materials = m_Materials.ToArray();
        // foreach (var mat in m_Materials)
        // {
        //     mat.color = SelectedObjectColor;
        // }
    }

    private void DeSelectObject()
    {
        // foreach (var mat in m_Materials)
        // {
        //     mat.color = Color.white;
        // }

        if (m_Materials == null)
        {
            return;
        }
        m_Materials.Remove(selectedObjMat);
        if (selectedObj == null)
        {
            return;
        }
        selectedObj.GetComponent<MeshRenderer>().materials = m_Materials.ToArray();
        selectedObj = null;
        m_Materials.Clear();
    }
}
