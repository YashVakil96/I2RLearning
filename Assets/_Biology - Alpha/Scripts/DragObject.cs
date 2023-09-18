using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    public void OnMouseDownMethod()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; 
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }


    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    
    public void OnMouseDragMethod()
    {
        if (Input.GetMouseButton(1))
        {
            return;
        }
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

}