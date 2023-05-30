using UnityEngine;

public class CheckOnCanvas : MonoBehaviour
{
    public static bool OnCanvasBool;

    public void OnMouseIn()
    {
        OnCanvasBool = true;
    }

    public void OnMouseOut()
    {
        OnCanvasBool = false;
    }
}