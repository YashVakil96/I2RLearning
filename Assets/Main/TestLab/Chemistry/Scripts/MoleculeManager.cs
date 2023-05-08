using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoleculeManager : MonoBehaviour
{
    public static MoleculeManager instance;
    public List<Molecule> _molecules;

    public List<Molecule> First;
    public List<Molecule> Second;

    public GameObject number1;
    public GameObject number2;

    public float duration;

    public bool firstSelected;


    private void Awake()
    {
        instance = this;
    }


    public void CreateBonds()
    {
        for (int i = 0; i < First.Count; i++)
        {
            var bond = Instantiate(new GameObject());
            bond.name = "Bond";
            var newLine = bond.AddComponent<LineRenderer>();
            newLine.sortingOrder = 5;
            bond.AddComponent<LineContainer>();
            bond.tag = "Bond";
            newLine.material = BondManager.Instance.singleBond;
            StartCoroutine(AnimateLine(newLine, First[i].transform.position, Second[i].transform.position));
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
        RemoveNumbers();
        lineRenderer.gameObject.AddComponent<AddEdgeColliderToLineRenderer>();
        BondManager.Instance.bonds.Add(lineRenderer);
        First.Clear();
        Second.Clear();
    }

    public void RemoveNumbers()
    {
        foreach (var obj in First)
        {
            Destroy(obj.transform.GetChild(0).gameObject);
        }

        foreach (var obj in Second)
        {
            Destroy(obj.transform.GetChild(0).gameObject);
        }
    }
}