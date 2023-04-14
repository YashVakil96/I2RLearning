using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnCanvas : MonoBehaviour
{
    public static bool OnCanvasBool;
    public void OnMouseIn()
    {
        OnCanvasBool = true;
        Debug.Log("On Mouse Over in");
    }

    public void OnMouseOut()
    {
        OnCanvasBool = false;
        Debug.Log("On Mouse Out");
    }
}