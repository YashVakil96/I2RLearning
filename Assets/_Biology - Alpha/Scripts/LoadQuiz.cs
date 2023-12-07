using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class LoadQuiz : MonoBehaviour
{
    public QuestionBankScriptableObjectScript quizBank;
    public List<QuestionData> questionDatas;
    public int questionCount;
    public TMP_Text question;
    public TMP_Text explaination;
    public GameObject mcqOptions;
    public GameObject labelSelectList;
    public GameObject labelPrefab;
    public GameObject submitButton;
    public GameObject nextQuestionButton;
    [HideInInspector] public GameObject model;
    public Transform modelObjTransform;
    
    
    public SelectObjectScript SelectObjectScriptRef;
    public LabelObjectScript LabelObjectScriptRef;
    public UIPages currentSelectedPage = UIPages.Select;


    private void Start()
    {
        questionDatas = quizBank.questionBank.ToList();
        ShowQuestion();
    }

    public void LoadSelectedObject(string objName)
    {
        var obj = Resources.Load("Models/" + objName) as GameObject;
        model = Instantiate(obj, Vector3.zero, Quaternion.identity, modelObjTransform);
    }
    
    public void ShowQuestion()
    {
        LoadSelectedObject(questionDatas[questionCount].objectName);
        question.text = questionDatas[questionCount].question;
        explaination.text = questionDatas[questionCount].explanation;
        mcqOptions.SetActive(false);    
        labelSelectList.SetActive(false);
        switch (questionDatas[questionCount].questionType)
        {
            case TypeOfQuestion.MultipleChoice:
                ChangeUIPage(UIPages.Select);
                mcqOptions.SetActive(true);
                for (int i = 0; i < mcqOptions.transform.childCount; i++)
                {
                    mcqOptions.transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text =
                        questionDatas[questionCount].answers[i];
                }
                break;
            
            case TypeOfQuestion.Label:
                labelSelectList.SetActive(true);
                ChangeUIPage(UIPages.Label);
                for (int i = 0; i < questionDatas[questionCount].selectedObjectsLabel.Count; i++)
                {
                    var a = Instantiate(labelPrefab, labelSelectList.transform);
                    a.transform.GetChild(1).GetComponent<TMP_Text>().text = questionDatas[questionCount].selectedObjectsLabel[i];
                }
                break;
            
            case TypeOfQuestion.SelectAnatomy:
                labelSelectList.SetActive(true);
                ChangeUIPage(UIPages.Select);
                for (int i = 0; i < questionDatas[questionCount].selectedObjectsLabel.Count; i++)
                {
                    labelSelectList.transform.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text =
                        questionDatas[questionCount].selectedObjectsLabel[i];
                }
                break;
            
            case TypeOfQuestion.Instruction:
                break;
        }
        //show next question and set all the elements
    }

    public void SubmitQuestion()
    {
        questionCount++;
        nextQuestionButton.SetActive(true);
    }

    public void NextQuestion()
    {
        if (questionCount >= questionDatas.Count)
        {
            Debug.Log("Quiz Over");
        }
        else
        {
            ShowQuestion();
            nextQuestionButton.SetActive(false);
        }
    }
    
    public void ChangeUIPage(UIPages page)
    {
        SelectObjectScriptRef.enabled = false;
        LabelObjectScriptRef.enabled = false;
        
        switch (page)
        {
            case UIPages.Select:
                SelectObjectScriptRef.enabled = true;
                break;
            case UIPages.Label:
                LabelObjectScriptRef.enabled = true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(page), page, null);
        }
        currentSelectedPage = page;

        
    }
}