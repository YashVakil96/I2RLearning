using System;
using System.Collections.Generic;
using UnityEngine;

public class ScaleData : MonoBehaviour
{
    public List<GameObject> scaleObjects;
    public int count =0; 

    [ContextMenu("Rename")]
    public void Rename()
    {
        foreach (var obj in scaleObjects)
        {
            obj.gameObject.name = count.ToString();
            count++;
        }

        count = 0;
    }
    [ContextMenu("Set Power")]
    public void SetScalePower()
    {
        foreach (var obj in scaleObjects)
        {
            obj.gameObject.GetComponent<ScalePower>().scalePower = count;
            count++;
        }
        count = 0;
    }
}
