using System.Collections.Generic;
using UnityEngine;

public class BondManager : MonoBehaviour
{
    public bool bondCreated;
    public GameObject currentBond;
    public LineRenderer currentLine;
    public Material singleBond;
    public List<LineRenderer> bonds;

    public GameObject previosSelected;

    private void Update()
    {
        if (!StateManager.IsCreating)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button Down");
            if (SelectMolecule.Selection() != null)
            {
                SelectMolecule.Selection().GetComponent<Molecule>().currentlySelected = true;
            }
            else
            {
                return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (CheckOnCanvas.OnCanvasBool)
            {
                return;
            }

            Debug.Log("Mouse button Hold");
            //start Creating Bond
            if (!bondCreated)
            {
                if (!CheckOnCanvas.OnCanvasBool)
                {
                    CreateBond();
                }
            }

            currentLine.SetPosition(1,
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)));
            //end point to mouse pos
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectMolecule.Selection() != null)
            {
                if (Vector2.Distance(currentLine.GetPosition(0), currentLine.GetPosition(1)) < .1f)
                {
                    bonds.Remove(currentLine);
                    Destroy(currentBond);
                }
                else
                {
                    var endPoint = SelectMolecule.Selection().gameObject;
                    currentLine.SetPosition(1, endPoint.transform.position);

                    var prevComponent = previosSelected.GetComponent<Molecule>();
                    prevComponent.NoOfBonds++;
                    prevComponent.bonds.Add(currentLine);
                    prevComponent.index.Add(0);


                    var endComponent = endPoint.GetComponent<Molecule>();
                    endComponent.NoOfBonds++;
                    endComponent.bonds.Add(currentLine);
                    endComponent.index.Add(1);

                    currentLine.GetComponent<LineContainer>().SetValues(currentLine, currentLine.GetPosition(0),
                        currentLine.GetPosition(1));

                    bonds.Add(currentLine);
                    currentBond.AddComponent<AddEdgeColliderToLineRenderer>();
                    currentBond = null;
                    currentLine = null;
                }
            }
            else
            {
                bonds.Remove(currentLine);
                Destroy(currentBond);
            }


            Debug.Log("Mouse button Up");
            bondCreated = false;
        }
    }

    public void CreateBond()
    {
        previosSelected = SelectMolecule.Selection().gameObject;
        currentBond = new GameObject("Bond");
        currentLine = currentBond.AddComponent<LineRenderer>();
        currentLine.useWorldSpace = true;
        currentBond.AddComponent<LineContainer>();
        currentLine.material = singleBond;
        currentLine.SetPosition(0, previosSelected.transform.position);
        bondCreated = true;
        currentBond.tag = "Bond";
    }
}