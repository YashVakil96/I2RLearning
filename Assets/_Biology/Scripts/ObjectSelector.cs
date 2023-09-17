using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    #region Public Variables

    [HideInInspector] 
    public static ObjectSelector Instance;

    #endregion
    
    #region Private Variables

     

    #endregion

    #region Unity Classes

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion
    
    #region Public Methods

    public SelectedObject SelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            SelectedObject so = new SelectedObject();
            so.selectedObject = hit.transform.gameObject;
            so.selectedPoint = hit.point;
            return so;
        }
        return null;
    }

    #endregion
    
    #region Private Methods

     

    #endregion
}
