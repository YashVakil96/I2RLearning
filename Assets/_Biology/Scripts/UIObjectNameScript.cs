using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIObjectNameScript : MonoBehaviour
{

    public TMP_Text objectNameText;
    public Transform lineEndPoint;


    private Camera m_Camera;
    private LineRenderer lineRenderer;

    private void Start()
    {
        m_Camera = Camera.main; 
        GetComponent<Canvas>().worldCamera = m_Camera;
        
        lineRenderer = GetComponent<LineRenderer>();
    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
        Vector3[] positions = {transform.position, lineEndPoint.position};
        lineRenderer.SetPositions(positions);
    }
}
