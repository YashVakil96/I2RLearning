using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;

public class TimelineScript : MonoBehaviour
{
    public GameObject freeLookCam;
    public PlayableDirector timeline;
    public PlayableDirector antiBody;
    public double prevValue = 0;
    public FreeCamera freeCam;
    public Camera cam;
    public CinemachineFreeLook bacteriaCam;
    public EnableCam enableCam;


    public void BacteriaCamButton()
    {
        StartCoroutine(HIVCam());
    }

    IEnumerator HIVCam()
    {
        enableCam.freeLook.enabled = !enableCam.freeLook.enabled;
        freeLookCam.SetActive(false);
        enableCam.freeLook = bacteriaCam;
        bacteriaCam.Priority = 11;
        bacteriaCam.enabled = true;
        yield return new WaitForEndOfFrame();
        enableCam.freeLook.enabled = !enableCam.freeLook.enabled;
    }
    

    public void PlayTimeline()
    {
        freeLookCam.SetActive(false);
        cam.transform.localPosition = Vector3.zero;
        cam.transform.localRotation = Quaternion.Euler(0,0,0);
        timeline.Play();
    }

    public void PlayAntiBody()
    {
        antiBody.Play();
    }

    private void Update()
    {
        Debug.Log(timeline.time);
        if (timeline.time > prevValue)
        {
            prevValue = timeline.duration;
        }

        if (prevValue == timeline.duration)
        {
            if (timeline.state  == PlayState.Paused)
            {
                Debug.Log("Joker");
                freeCam.enabled = true;
            }
        }
    }
}
