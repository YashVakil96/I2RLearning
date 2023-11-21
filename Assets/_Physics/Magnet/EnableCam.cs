using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableCam : Singleton<EnableCam>
{
    // Start is called before the first frame update

    public static EnableCam instance;
    public CinemachineFreeLook freeLook;
    public float scrollSensitivity = 5;
    public bool ifCameraInTransition;
    public bool rightClickEnable;
    public bool canRotateCamera;

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
        if (SceneManager.GetActiveScene().name =="MeterBridge" )
        {
            if (MoveObject.isDragging)
            {
                return;
            }    
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
                if (canRotateCamera)
                {
                    if (Input.GetMouseButton(0))
                    {
                        EnableFreeLook();
                        // freeLook.enabled = true;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        DisableFreeLook();
                        // freeLook.enabled = false;
                    }        
                }
                
            }
            

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                StartCoroutine(Zoom());
            }    
        }
        
    }

    public void EnableFreeLook()
    {
        freeLook.enabled = true;
    }
    
    public void DisableFreeLook()
    {
        freeLook.enabled = false;
    }

    public void CanRotateCamera()
    {
        canRotateCamera = true;
    }
    public void CannotRotateCamera()
    {
        canRotateCamera = false;
    }
    


    IEnumerator Zoom()
    {
        freeLook.enabled = !freeLook.enabled;

        freeLook.m_Lens.FieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        yield return new WaitForEndOfFrame();
        freeLook.enabled = !freeLook.enabled;
    }
}