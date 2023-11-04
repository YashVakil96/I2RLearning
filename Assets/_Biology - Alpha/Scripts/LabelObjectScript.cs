using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class LabelObjectScript : Singleton<LabelObjectScript>
{
    // public GameObject uiPointPrefab;
    public GameObject uiPointPrefab;
    public GameObject labelUiPanel;
    public GameObject labelUiObjectPrefab;
    public Transform content;
    public List<UIObjectNameScript> uiPointsList = new List<UIObjectNameScript>();


    private void OnEnable()
    {
        Init();
    }
    

    public void Init()
    {
        if (UIManager.Instance.bottomHudScript.quizOn)
        {
            
        }
        else
        {
            labelUiPanel.SetActive(true);    
        }
        
    }
    
    private void Update()
    {
        if (GameManager.Instance.currentSelectedPage == UIPages.Label)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateLabelOnSelectedPoint();
            }    
        }
    }

    private void CreateLabelOnSelectedPoint()
    {
        var obj = ObjectSelector.Instance.SelectObject();
        if (obj == null)
        {
            return;
        }

        if (uiPointsList.Any(item => item.gameObject.name == "UI " + obj.selectedObject.name))
        {
            return;
        }
        
        var ui = Instantiate(uiPointPrefab, obj.selectedPoint, Quaternion.identity);
        var uiScript = ui.GetComponent<UIObjectNameScript>();
        
        ui.name = "UI " + obj.selectedObject.name;
        uiScript.objectNameText.text = obj.selectedObject.name;
        
        uiPointsList.Add(uiScript);
        var uiObject =Instantiate(labelUiObjectPrefab, content);
        uiObject.GetComponent<LabelUiObject>().name = obj.selectedObject.name;
        uiObject.GetComponent<LabelUiObject>().Init();
        uiObject.GetComponent<LabelUiObject>().uiGameObject = ui;

        if (GameManager.Instance.currentSelectedPage == UIPages.Quiz)
        {
            if (GameManager.Instance.addQuestion.currentQuestion.GetComponent<QuestionScript>().questionType ==TypeOfQuestion.Label ||GameManager.Instance.addQuestion.currentQuestion.GetComponent<QuestionScript>().questionType ==TypeOfQuestion.SelectAnatomy)
            {
                GameManager.Instance.addQuestion.currentQuestion.GetComponent<QuestionScript>().AddLabelList(uiScript.objectNameText.text);
            }
        }
        
    }

    public void RemoveLabel(GameObject uiObject)
    {
        uiPointsList.Remove(uiObject.GetComponent<UIObjectNameScript>());
    }

    private void OnDisable()
    {
        if (uiPointsList == null)
        {
            return;
        }
        foreach (var item in uiPointsList)
        {
            Destroy(item.gameObject);
        }
        labelUiPanel.SetActive(false);
        uiPointsList.Clear();
    }
}
