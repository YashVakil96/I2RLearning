using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.Collections;
using UnityEngine;

public class SelectObjectScript : MonoBehaviour
{
    private GameObject selectedObj = null;
    public Color SelectedObjectColor = Color.yellow;
    public Material selectedObjMat;
    public GameObject previousSelected;


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
            previousSelected = selectedObj;
            DeSelectObject();
        }
        selectedObj = a.selectedObject;
        m_Materials = selectedObj.GetComponent<MeshRenderer>().materials.ToList();
        m_Materials.Add(selectedObjMat);
        selectedObj.GetComponent<MeshRenderer>().materials = m_Materials.ToArray();
        var count = UndoRedo.Instance.undoSelectedObject.Count;
        if (count>0)
        {
            if (selectedObj.name == UndoRedo.Instance.undoSelectedObject[count-1].name)
            {
                return;
            }    
        }

        if (previousSelected!=null)
        {
            UndoRedo.Instance.undoSelectedObject.Add(previousSelected);
        }

        UndoRedo.Instance.UndoButtonInteractable();
    }

    public void DeSelectObject()
    {
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

    public void Selection(GameObject selectedObject)
    {
        selectedObj =selectedObject;
        m_Materials = selectedObj.GetComponent<MeshRenderer>().materials.ToList();
        m_Materials.Add(selectedObjMat);
        selectedObj.GetComponent<MeshRenderer>().materials = m_Materials.ToArray();
    }
}
