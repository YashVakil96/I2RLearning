using UnityEngine;

public class EditBonds : MonoBehaviour
{
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
                if (hitInfo.collider.gameObject.name =="Bond")
                {
                    Debug.Log("Mark to delete");
                    
                }
                /*else if ()
                {
                    
                }*/
            }        
        }
    }
}
