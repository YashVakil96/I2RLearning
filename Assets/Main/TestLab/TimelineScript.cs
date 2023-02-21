using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;

public class TimelineScript : MonoBehaviour
{
    public PlayableDirector timeline;
    public double prevValue = 0;
    public FreeCamera freeCam;

    public void PlayTimeline()
    {
        timeline.Play();
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
