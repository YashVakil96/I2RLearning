using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class HideObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject showHidePrefab;
    public GameObject showHidePanel;
    public Transform content;
    public GameObject model;
    public List<GameObject> modelParts;
    public bool isObjectHide;


    public void Init()
    {
        isObjectHide = true;
        model = GameManager.Instance.model;
        if (modelParts.Count>0)
        {
        }
        else
        {
            for (int i = 0; i < model.transform.childCount; i++)
            {
                var temp = Instantiate(showHidePrefab, content);
                 
                temp.GetComponent<ShowHideUIObject>().partNameText.text = model.transform.GetChild(i).name;
                temp.GetComponent<ShowHideUIObject>().part = model.transform.GetChild(i).gameObject;
                temp.GetComponent<ShowHideUIObject>().ForceShow();
                temp.name = model.transform.GetChild(i).name;
                modelParts.Add(temp);
            }    
        }
        showHidePanel.SetActive(true);
    }

    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        if (GameManager.Instance.currentSelectedPage ==UIPages.Hide)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var a = ObjectSelector.Instance.SelectObject();
                var tt = a.selectedObject;
                Debug.Log(a.selectedObject.name,a.selectedObject);
                a.selectedObject.SetActive(false);
                GameObject temp;
                foreach (var item in modelParts.Where(item => item.name == tt.name))
                {
                    item.GetComponent<ShowHideUIObject>().ShowHide();
                    break;
                }
                

            }    
        }
        
        
    }

    private void OnDisable()
    {
        // RevertAll();
    }

    public void RevertAll()
    {
        for (int i = 0; i < model.transform.childCount; i++)
        {
            model.transform.GetChild(i).gameObject.SetActive(true);
        }   
        // showHidePanel.SetActive(false);
    }
}
