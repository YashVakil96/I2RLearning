using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BondManager : MonoBehaviour
{
    public static BondManager Instance;

    public bool bondCreated;
    public GameObject currentBond;
    public LineRenderer currentLine;
    public Material singleBond;
    public List<LineRenderer> bonds;

    public GameObject previosSelected;
    public float desiredDistance = 5f;

    public float timeToDecrease = 5.0f;

    public float duration;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!StateManager.Instance.createState)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (CheckOnCanvas.OnCanvasBool)
            {
                return;
            }
            else
            {
                // Debug.Log("Mouse button Down");
                if (AtomManager.Selection() == null)
                {
                    AtomManager.Selection().GetComponent<Molecule>().currentlySelected = true;
                }
                else
                {
                    return;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (CheckOnCanvas.OnCanvasBool)
            {
                return;
            }

            // Debug.Log("Mouse button Hold");
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
            if (AtomManager.Selection() != null)
            {
                if (Vector2.Distance(currentLine.GetPosition(0), currentLine.GetPosition(1)) < .1f)
                {
                    bonds.Remove(currentLine);
                    Destroy(currentBond);
                }
                else
                {
                    var endPoint = AtomManager.Selection().gameObject;

                    currentLine.SetPosition(1, endPoint.transform.position);

                    var prevComponent = previosSelected.GetComponent<Molecule>();
                    prevComponent.NoOfBonds++;
                    prevComponent.bonds.Add(currentLine);
                    prevComponent.index.Add(0);

                    if (endPoint == null)
                    {
                        bonds.Remove(currentLine);
                        Destroy(currentBond);
                        return;
                    }

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

            bondCreated = false;
        }
    }

    private void CreateBond()
    {
        previosSelected = AtomManager.Selection().gameObject;
        currentBond = new GameObject("Bond");
        currentLine = currentBond.AddComponent<LineRenderer>();
        currentLine.useWorldSpace = true;
        currentBond.AddComponent<LineContainer>();
        currentLine.material = singleBond;
        currentLine.SetPosition(0, previosSelected.transform.position);
        bondCreated = true;
        currentBond.tag = "Bond";
        currentLine.sortingOrder = 5;
    }

    public void RemoveBonds()
    {
        foreach (var bond in bonds.Where(bond => bond.GetComponent<LineContainer>().markedToDelete))
        {
            StartCoroutine(DecreaseWidthOverTime(bond));
            // bond.gameObject.SetActive(false);
            Debug.Log(bond.name + " Delete");
        }

        foreach (var bond in bonds.Where(bond => bond.GetComponent<LineContainer>().markedToDelete))
        {
            bonds.Remove(bond);
        }
    }

    IEnumerator DecreaseWidthOverTime(LineRenderer lineRenderer)
    {
        float timeElapsed = 0.0f; // current time elapsed

        while (timeElapsed < timeToDecrease)
        {
            // calculate the new line width based on the elapsed time
            float newWidth = Mathf.Lerp(1, 0.0f, timeElapsed / timeToDecrease);
            lineRenderer.startWidth = newWidth;
            lineRenderer.endWidth = newWidth;

            timeElapsed += Time.deltaTime; // increase the elapsed time
            yield return null; // wait for the next frame
        }

        // ensure that the line width is set to 0 at the end of the coroutine
        lineRenderer.startWidth = 0.0f;
        lineRenderer.endWidth = 0.0f;
        lineRenderer.gameObject.SetActive(false);
    }

    public void AnimateBonds()
    {
        for (int i = 0; i < AtomManager.instance.First.Count; i++)
        {
            var bond = Instantiate(new GameObject());
            bond.name = "Bond";
            var newLine = bond.AddComponent<LineRenderer>();
            newLine.sortingOrder = 5;
            bond.AddComponent<LineContainer>();
            bond.tag = "Bond";
            newLine.material = BondManager.Instance.singleBond;
            StartCoroutine(AnimateLine(newLine, AtomManager.instance.First[i].transform.position,
                AtomManager.instance.Second[i].transform.position));
        }
    }

    IEnumerator AnimateLine(LineRenderer lineRenderer, Vector3 pointA, Vector3 pointB)
    {
        lineRenderer.SetPosition(0, pointA);
        lineRenderer.SetPosition(1, pointA);
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            // Calculate how far along we are in the animation
            float t = (Time.time - startTime) / duration;

            // Update the line renderer's second position
            Vector3 pos = Vector3.Lerp(pointA, pointB, t);
            lineRenderer.SetPosition(1, pos);

            // Update the line renderer's width to make it appear to be tapering off
            float width = Mathf.Lerp(1f, 1f, t);
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;

            yield return null;
        }

        // Set the line renderer's final positions and widths
        lineRenderer.SetPosition(1, pointB);
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        AtomManager.instance.RemoveNumbers();
        lineRenderer.gameObject.AddComponent<AddEdgeColliderToLineRenderer>();
        BondManager.Instance.bonds.Add(lineRenderer);
        AtomManager.instance.First.Clear();
        AtomManager.instance.Second.Clear();
    }
}