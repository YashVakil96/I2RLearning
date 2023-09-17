using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;

public class TimelineScript : MonoBehaviour
{

    public static TimelineScript instance;
    public GameObject freeLookCam;
    public PlayableDirector timeline;
    public PlayableDirector antiBody;
    public double prevValue = 0;
    public FreeCamera freeCam;
    public Camera cam;

    private void Awake()
    {
        instance = this;
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
        if (timeline.time > prevValue)
        {
            prevValue = timeline.duration;
        }

        if (prevValue == timeline.duration)
        {
            if (timeline.state  == PlayState.Paused)
            {
                freeCam.enabled = true;
            }
        }
    }
}