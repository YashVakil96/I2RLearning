using System.Collections;
using Cinemachine;
using UnityEngine;

public class EnableCam : MonoBehaviour
{
    // Start is called before the first frame update

    public static EnableCam instance;
    public CinemachineFreeLook freeLook;
    public float scrollSensitivity = 5;
    public bool ifCameraInTransition;
    public bool rightClickEnable;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        freeLook.enabled = false;
    }

    private void Update()
    {
        if (MoveObject.isDragging)
        {
            return;
        }
        if (!ifCameraInTransition)
        {
            if (rightClickEnable)
            {
                if (Input.GetMouseButton(1))
                {
                    freeLook.enabled = true;
                }

                if (Input.GetMouseButtonUp(1))
                {
                    freeLook.enabled = false;
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    freeLook.enabled = true;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    freeLook.enabled = false;
                }    
            }
            

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                StartCoroutine(Zoom());
            }    
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