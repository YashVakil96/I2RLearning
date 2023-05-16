using UnityEditor;
using UnityEngine;

public class DeleteSelected : MonoBehaviour
{
    void Update()
    {
        if (StateManager.IsDeleting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition =
                    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                RaycastHit2D hitInfo = new RaycastHit2D();
                hitInfo = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hitInfo.collider != null)
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }
}