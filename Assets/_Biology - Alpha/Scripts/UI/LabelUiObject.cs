using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LabelUiObject : MonoBehaviour
{

    public TMP_Text nameText;
    public string name;
    public GameObject uiGameObject;
    

    public void Init()
    {
        nameText.text = name;
    }
    public void OnAddButton()
    {
        
    }

    public void OnRemoveButton()
    {
        LabelObjectScript.Instance.RemoveLabel(uiGameObject);
        Destroy(uiGameObject);
        Destroy(gameObject);
        
    }

    public void OnArrowButton()
    {
        
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
