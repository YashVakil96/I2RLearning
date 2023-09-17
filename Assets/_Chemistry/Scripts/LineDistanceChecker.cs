using System;
using System.Net;
using UnityEngine;

public class LineDistanceChecker : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float desiredDistance = 5f;
    public GameObject endPointObject;


    private Vector3 startPoint;
    private Vector3 endPoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Check for mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            // Get the position of the Line Renderer's first point
            startPoint = lineRenderer.GetPosition(0);

            // Calculate the direction from the start point to the mouse position
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPoint).normalized;

            // Set the endpoint to the desired distance along the direction
            endPoint = startPoint + direction * desiredDistance;

            // Update the Line Renderer's positions
            lineRenderer.SetPosition(1, endPoint);
        }
    }

    public void MoveObjectToEndPoint()
    {
        if (endPointObject != null)
        {
            endPointObject.transform.position = endPoint;
        }
    }
}