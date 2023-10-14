using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionScript : MonoBehaviour
{
    public TypeOfQuestion questionType;

    public GameObject mcqOptions;
    public GameObject labelList;
    public GameObject labelOption;

    // Start is called before the first frame update
    private void OnEnable()
    {
        switch (questionType)
        {
            case TypeOfQuestion.MultipleChoice:
                GameManager.Instance.ChangeUIPage(UIPages.Select);
                break;
            case TypeOfQuestion.SelectAnatomy:
                GameManager.Instance.ChangeUIPage(UIPages.Select);
                break;
            case TypeOfQuestion.Label:
                GameManager.Instance.ChangeUIPage(UIPages.Label);
                break;
            case TypeOfQuestion.Instruction:
                GameManager.Instance.ChangeUIPage(UIPages.Select);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void Start()
    {

        mcqOptions.SetActive(false);
        labelList.SetActive(false);
        switch (questionType)
        {
            case TypeOfQuestion.MultipleChoice:
                mcqOptions.SetActive(true);
                break;
            
            case TypeOfQuestion.Label:
                labelList.SetActive(true);
                break;
            
            case TypeOfQuestion.SelectAnatomy:
                labelList.SetActive(true);
                break;
        }
        
    }

    public void AddLabelList(string labelText)
    {
        var temp =Instantiate(labelOption, labelList.transform.GetChild(0).transform.GetChild(0));
        temp.transform.GetChild(1).GetComponent<TMP_Text>().text = labelText;
    }
}