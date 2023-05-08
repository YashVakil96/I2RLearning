using DG.Tweening;
using UnityEngine;

public class EditBonds : MonoBehaviour
{
    public GameObject cross;

    void Update()
    {
        if (!StateManager.IsEditing)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition =
                    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                RaycastHit2D hitInfo = new RaycastHit2D();
                hitInfo = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hitInfo.collider.gameObject.name == "Bond")
                {
                    var LineObject = hitInfo.collider.gameObject;
                    Debug.Log("Mark to delete");
                    var crossObj = Instantiate(cross, hitInfo.collider.gameObject.transform);
                    crossObj.transform.position = MidPoint(LineObject.GetComponent<LineRenderer>().GetPosition(0),
                        LineObject.GetComponent<LineRenderer>().GetPosition(1));
                    crossObj.transform.DOScale(0.1f, .3f);
                    LineObject.GetComponent<LineContainer>().markedToDelete = true;
                }

                /*else if ()*
                {
                    
                }*/
            }
        }
    }

    public Vector3 MidPoint(Vector3 point1, Vector3 point2)
    {
        Vector3 midpoint = (point1 + point2) / 2f;
        return midpoint;
    }
}