using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float zoomSpeed = 20f;
    public float minZoom = 1f;
    public float maxZoom = 10f;

    private bool isPanning = false;
    private Vector3 lastPanPosition;

    void Update()
    {
        // Pan the camera using middle mouse button
        if (Input.GetMouseButtonDown(2))
        {
            isPanning = true;
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(2))
        {
            isPanning = false;
        }

        if (isPanning)
        {
            Vector3 panDirection = lastPanPosition - Input.mousePosition;
            transform.Translate(panDirection * panSpeed * Time.deltaTime);
            lastPanPosition = Input.mousePosition;
        }

        // Zoom the camera using the scroll wheel
        float zoomInput = Input.GetAxis("Mouse ScrollWheel") * 0.5f;
        float newZoom = Camera.main.orthographicSize - zoomInput * zoomSpeed;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);
        Camera.main.orthographicSize = newZoom;
    }
}