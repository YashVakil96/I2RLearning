using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AtomManager : MonoBehaviour
{
    public static AtomManager instance;

    [Header("Create")] public GameObject molecule;
    public float raycastDistance = 1f; // Distance to cast the rays
    public float spawnDistance = 2f; // Distance to spawn the new object

    public List<Molecule> _molecules;

    public List<Molecule> First;
    public List<Molecule> Second;

    public GameObject number1;
    public GameObject number2;

    public bool firstSelected;

    private GameObject a, b;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (StateManager.Instance.currentState)
        {
            case StateManager.CurrentState.CreateState:

                if (Input.GetMouseButtonDown(0))
                {
                    if (!CheckOnCanvas.OnCanvasBool)
                    {
                        Vector2 mousePosition =
                            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                        RaycastHit2D hitInfo = new RaycastHit2D();
                        hitInfo = Physics2D.Raycast(mousePosition, Vector2.zero);
                        if (hitInfo.collider != null)
                        {
                            Debug.Log(hitInfo.collider.name);
                            return;
                        }

                        CreateAtom();
                    }
                }

                break;

            case StateManager.CurrentState.DeleteState:
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

                break;

            case StateManager.CurrentState.EditState:

                if (Input.GetMouseButtonDown(0))
                {
                    if (Selection() != null)
                    {
                        if (Selection().gameObject.CompareTag("Molecule"))
                        {
                            var obj = Selection().GetComponent<Molecule>();
                            if (firstSelected)
                            {
                                Second.Add(obj);
                                firstSelected = false;
                                b = Instantiate(number2, obj.transform);
                            }
                            else
                            {
                                First.Add(obj);
                                firstSelected = true;
                                a = Instantiate(number1, obj.transform);
                            }
                        }
                    }
                }

                break;

            case StateManager.CurrentState.MoveState:
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
                break;
        }
    }

    private void CreateAtom()
    {
        var a = Instantiate(molecule,
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5)),
            quaternion.identity);
        a.tag = "Molecule";
    }

    public void RemoveNumbers()
    {
        foreach (var obj in First)
        {
            // Debug.Log(obj.transform.GetChild(10).gameObject.name);
            Destroy(obj.transform.GetChild(obj.transform.childCount - 1).gameObject);
        }

        foreach (var obj in Second)
        {
            // Debug.Log(obj.transform.GetChild(10).gameObject.name);
            Destroy(obj.transform.GetChild(obj.transform.childCount - 1).gameObject);
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