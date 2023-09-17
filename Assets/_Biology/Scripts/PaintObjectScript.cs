using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaintObjectScript : MonoBehaviour
{
    public List<GameObject> coloredObj = new List<GameObject>();
    public Color SelectedObjectColor = Color.yellow;
    public List<Material> m_Materials = new List<Material>();
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

        if (coloredObj.Contains(a.selectedObject))
        {
            return;
        }
        
        coloredObj.Add(a.selectedObject);
        m_Materials.AddRange(a.selectedObject.GetComponent<MeshRenderer>().materials.ToList());
        foreach (var mat in m_Materials)
        {
            mat.color = SelectedObjectColor;
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
