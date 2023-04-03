using Cinemachine;
using UnityEngine;

public class SelectMolecule : MonoBehaviour
{
    public CreateMolecule createMolecule;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Selection() != null)
            {
                Debug.Log("Hit " + Selection().gameObject.name);
            }
            else
            {
                if (StateManager.IsCreating)
                {
                    createMolecule.Create();
                }
            }
        }
    }

    public static Collider2D Selection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitInfo = new RaycastHit2D();
        hitInfo = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hitInfo.collider != null)
        {
            return hitInfo.collider;
        }
        else
        {
            return null;
        }
    }
}