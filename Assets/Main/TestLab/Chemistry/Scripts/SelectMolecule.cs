using System.Security.Cryptography;
using UnityEngine;

public class SelectMolecule : MonoBehaviour
{
    public CreateMolecule createMolecule;
    private GameObject a, b;

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
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;

                            if (Physics.Raycast(ray, out hit))
                            {
                                // Check if the raycast hit an object with a collider
                                if (hit.collider != null)
                                {
                                    Debug.Log("Overlap detected! Cannot create item.");
                                    return;
                                }
                            }

                            // No overlap detected, create the item at the mouse position
                            // Instantiate(itemPrefab, hit.point, Quaternion.identity);
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

        if (StateManager.IsEditing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Selection().gameObject.CompareTag("Molecule"))
                {
                    var obj = Selection().GetComponent<Molecule>();
                    if (MoleculeManager.instance.firstSelected)
                    {
                        MoleculeManager.instance.Second.Add(obj);
                        MoleculeManager.instance.firstSelected = false;
                        b = Instantiate(MoleculeManager.instance.number2, obj.transform);
                    }
                    else
                    {
                        MoleculeManager.instance.First.Add(obj);
                        MoleculeManager.instance.firstSelected = true;
                        a = Instantiate(MoleculeManager.instance.number1, obj.transform);
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
            if (hitInfo.collider.gameObject.CompareTag("Molecule"))
            {
                return hitInfo.collider;
            }
        }

        return null;
    }
}