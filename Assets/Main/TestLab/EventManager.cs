using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public EnableCam enableCam;
    public State state;

    public GameObject antibodyButton;
    public GameObject nextButton, prevButton;

    public List<GameObject> stateObjects;

    public CinemachineFreeLook manCam, hivCam, cd4Cam, medCam;
    public List<CinemachineFreeLook> camList;

    private void Awake()
    {
        instance = this;
        camList.Add(manCam);
        camList.Add(hivCam);
        camList.Add(cd4Cam);
        camList.Add(medCam);
        
        antibodyButton.SetActive(false);
        nextButton.SetActive(false);
        prevButton.SetActive(false);
    }

    private void Start()
    {
        state = State.Man;
        Man();
    }

    void HideObjects(int index)
    {
        for (int i = 0; i < stateObjects.Count; i++)
        {
            if (i == index)
            {
                stateObjects[i].SetActive(true);
            }
            else
            {
                stateObjects[i].SetActive(false);
            }
        }
    }


    IEnumerator EnableSingleCam(CinemachineFreeLook camToEnable)
    {
        /*enableCam.freeLook.enabled = !enableCam.freeLook.enabled;
        freeLookCam.SetActive(false);
        enableCam.freeLook = bacteriaCam;
        bacteriaCam.Priority = 11;
        bacteriaCam.enabled = true;
        yield return new WaitForEndOfFrame();
        enableCam.freeLook.enabled = !enableCam.freeLook.enabled;*/
        EnableCam.instance.freeLook.enabled = !EnableCam.instance.freeLook.enabled;
        EnableCam.instance.ifCameraInTransition = true;        
        foreach (var cam in camList)
        {
            cam.gameObject.SetActive(false);
        }
        EnableCam.instance.freeLook = camToEnable;
        camToEnable.enabled = true;
        camToEnable.gameObject.SetActive(true);

        EnableCam.instance.ifCameraInTransition = false;

            yield return new WaitForEndOfFrame();
            EnableCam.instance.freeLook.enabled = !EnableCam.instance.freeLook.enabled;
            

    }

    public void Man()
    {
        HideObjects(0);
        StartCoroutine(EnableSingleCam(manCam));
    }

    public void Inside()
    {
        antibodyButton.SetActive(true);
        foreach (var cam in camList)
        {
            cam.gameObject.SetActive(false);
        }
        TimelineScript.instance.PlayTimeline();
        HideObjects(1);
        foreach (var cam in camList)
        {
            cam.enabled = false;
        }
    }

    public void HIV()
    {
        nextButton.SetActive(true);
        prevButton.SetActive(true);
        HideObjects(2);
        StartCoroutine(EnableSingleCam(hivCam));
    }

    public void CD4()
    {
        HideObjects(3);
        StartCoroutine(EnableSingleCam(cd4Cam));
    }

    public void VirusMed()
    {
        HideObjects(4);
        StartCoroutine(EnableSingleCam(medCam));
    }


    public void JumpToEvent(int enumState)
    {

        antibodyButton.SetActive(false);
        nextButton.SetActive(false);
        prevButton.SetActive(false);
        switch ((State)enumState)
        {
            case State.Man:
                Man();
                break;

            case State.Inside:
                Inside();
                break;

            case State.HIV:
                HIV();
                break;

            case State.CD4:
                CD4();
                break;

            case State.VirusMed:
                VirusMed();
                break;
        }
    }


    public enum State
    {
        Man = 0,
        Inside = 1,
        Antibody = 2,
        HIV = 3,
        CD4 = 4,
        VirusMed = 5
    }
}