using System.IO;
using Cinemachine;
using UnityEngine;

public class SelectMolecule : MonoBehaviour
{
    public CreateMolecule createMolecule;

    private void Update()
    {
        if (StateManager.IsCreating)

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
                        if (!CheckOnCanvas.OnCanvasBool)
                        {
                            createMolecule.Create();
                        }
                    }
                }
            }


        if (StateManager.IsMoving)
        {
            if (Input.GetMouseButton(0))
            {
                if (Selection().gameObject.CompareTag("Molecule"))
                {
                    var moveObject = Selection().gameObject;
                    var moveObjectMolecule = moveObject.GetComponent<Molecule>();

                    moveObject.transform.position =
                        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

                    for (int i = 0; i < moveObjectMolecule.NoOfBonds; i++)
                    {
                        moveObjectMolecule.bonds[i]
                            .SetPosition(moveObjectMolecule.index[i], moveObject.transform.position);

                        moveObjectMolecule.bonds[i].GetComponent<AddEdgeColliderToLineRenderer>().AdjustLineStartAndEnd(
                            moveObjectMolecule.bonds[i], moveObjectMolecule.bonds[i].GetComponent<EdgeCollider2D>(),
                            moveObject.transform.position, moveObjectMolecule.bonds[i].GetPosition(1));
                    }
                }
            }
        }
    }

    public static Collider2D Selection()
    {
        Vector2 mousePosition =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
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