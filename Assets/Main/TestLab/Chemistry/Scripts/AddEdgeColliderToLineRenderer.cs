using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class AddEdgeColliderToLineRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    public static Vector3 start;
    public static Vector3 end;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {
        SetPoints();
    }

    private void Update()
    {
        if (StateManager.IsMoving)
        {
            
        }
    }

    private void SetPoints()
    {
        Vector2[] points = new Vector2[lineRenderer.positionCount];

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            points[i] = lineRenderer.GetPosition(i);
        }

        edgeCollider.points = points;
    }

    public void AdjustLineStartAndEnd(LineRenderer line, EdgeCollider2D edge, Vector3 lineStart, Vector3 lineEnd)
    {
        line.SetPosition(0, lineStart);
        line.SetPosition(1, lineEnd);
        edge.points = new Vector2[] {lineStart, lineEnd};
    }
}