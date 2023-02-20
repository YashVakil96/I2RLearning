using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EnableCam : MonoBehaviour
{
    // Start is called before the first frame update

    public CinemachineFreeLook freeLook;
    public float scrollSensitivity = 5;

    private void Start()
    {
        freeLook.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            freeLook.enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            freeLook.enabled = false;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            StartCoroutine(Zoom());
        }
    }

    /*void Zoom()
    {
        freeLook.enabled = !freeLook.enabled;

        freeLook.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        
    }*/

    IEnumerator Zoom()
    {
        freeLook.enabled = !freeLook.enabled;

        freeLook.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        yield return new WaitForEndOfFrame();
        freeLook.enabled = !freeLook.enabled;
    }
}