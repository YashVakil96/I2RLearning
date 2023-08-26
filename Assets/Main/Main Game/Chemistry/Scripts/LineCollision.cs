using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class LineCollision : MonoBehaviour
{
    private EdgeCollider2D _edgeCollider2D;
    private LineRenderer line;
    void Start()
    {
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
        line = GetComponent<LineRenderer>();
        _edgeCollider2D.isTrigger = true;
        _edgeCollider2D.edgeRadius = 0.2f;
    }
    
    void Update()
    {
        SetCollider(line);
        
    }

    void SetCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(i);
            edges.Add(new Vector2(lineRendererPoint.x,lineRendererPoint.y));
        }

        _edgeCollider2D.SetPoints(edges);
        
    }
}
