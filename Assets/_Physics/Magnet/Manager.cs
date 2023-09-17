using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class Manager : MonoBehaviour
{
    public CinemachineVirtualCamera dollyCam;
    public CinemachineFreeLook freeLook;
    public PlayableDirector pd;

    private void Start()
    {
        
        freeLook.enabled = false;
        dollyCam.Priority = 100;
    }

    private void Update()
    {
        var path = dollyCam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition;
        Debug.Log(path);
        if (path > 1)
        {
            dollyCam.enabled = false;
        }
    }

    public void PlayCam()
    {
        pd.Play();
        
    }
}