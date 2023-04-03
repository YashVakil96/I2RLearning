using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Camera myCam;
    public Animator anim;

    private float startXPos;
    private float startYPos;

    public static bool isDragging = false;

    public void StopAnimation()
    {
        anim.enabled = true;
        StartCoroutine(C_StopAnimation());
    }

    IEnumerator C_StopAnimation()
    {
        yield return new WaitForSeconds(1.1f);
        anim.enabled = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!myCam.orthographic)
        {
            mousePos.z = 10;
        }

        mousePos = myCam.ScreenToWorldPoint(mousePos);
        if (transform.position.x > 1.5f )
        {
            transform.localPosition =
                new Vector3(1.47f, transform.localPosition.y, transform.localPosition.z);
            isDragging = false;
            return;
        }
        else if (transform.position.x < -2.1f)
        {
            
            transform.localPosition =
                new Vector3(-2f, transform.localPosition.y, transform.localPosition.z);
            isDragging = false;
            return;
        }

        transform.localPosition =
            new Vector3(mousePos.x - startXPos, transform.localPosition.y, transform.localPosition.z);
    }
}