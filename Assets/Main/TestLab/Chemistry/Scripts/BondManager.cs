using System.Collections.Generic;
using UnityEngine;

public class BondManager : MonoBehaviour
{
    public bool bondCreated;
    public GameObject currentBond;
    public LineRenderer currentLine;
    public Material singleBond;

    public List<LineRenderer> bonds;

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
            Debug.Log("Mouse button Hold");
            //start Creating Bond
            if (!bondCreated)
            {
                CreateBond();
            }

            currentLine.SetPosition(1,
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)));
            //end point to mouse pos
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectMolecule.Selection() != null)
            {
                currentLine.SetPosition(1, SelectMolecule.Selection().gameObject.transform.position);
            }
            else
            {
                Destroy(currentBond);
            }

            if (Vector2.Distance(currentLine.GetPosition(0), currentLine.GetPosition(1)) < .1f)
            {
                Destroy(currentBond);
            }

            Debug.Log("Mouse button Up");
            bondCreated = false;
        }
    }

    public void CreateBond()
    {
        currentBond = new GameObject("Bond");
        currentLine = currentBond.AddComponent<LineRenderer>();
        currentLine.material = singleBond;
        currentLine.SetPosition(0, SelectMolecule.Selection().gameObject.transform.position);
        bondCreated = true;
    }
}