using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamOrbit : MonoBehaviour
{
    public Transform cam;
    public Transform parent;

    public Vector3 localRotation;
    public float cameraDistance = 10f;

    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;

    public bool cameraDisabled;
    
    private void Start()
    {
        cam = transform;
        parent = transform.parent;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cameraDisabled = !cameraDisabled;
        }

        if (!cameraDisabled)
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                scrollAmount *= (cameraDistance * .3f);

                cameraDistance += scrollAmount * -1f;

                cameraDistance = Mathf.Clamp(cameraDistance, 1.5f, 100f);
            }
        }

        Quaternion qt = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        parent.rotation = Quaternion.Lerp(parent.rotation, qt, Time.deltaTime * orbitDampening);

        if (cam.localPosition.z != cameraDistance * -1f)
        {
            cam.localPosition = new Vector3(0f, 0f, Mathf.Lerp(cam.localPosition.z,cameraDistance*-1f,Time.deltaTime*scrollDampening));  
        }
    }
}