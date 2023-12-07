using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class AddQuestion : MonoBehaviour
{
    public GameObject addQuestionButton;
    public GameObject questionObject;
    public GameObject content;
    public GameObject addButton;
    public GameObject dropdownButton;
    public TMP_Dropdown drop;
    public GameObject currentQuestion;
    public List<QuestionScript> queList;
    public GameObject saveButton;

    private void Awake()
    {
        // addButton = Instantiate(addQuestionButton, content.transform);
        // addButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => AddNewQuestion());
        // dropdownButton = GameObject.Find("Dropdown");
        // drop = FindObjectOfType<TMP_Dropdown>();
        // drop.onValueChanged.AddListener(arg0 => AddNewQuestion());
        // dropdownButton.SetActive(false);
    }

    private void OnEnable()
    {
        dropdownButton.SetActive(true);
        drop = dropdownButton.GetComponent<TMP_Dropdown>();
        drop.onValueChanged.AddListener(arg0 => AddNewQuestion());
        dropdownButton.SetActive(false);
    }

    public void AddNewQuestion()
    {
        // Debug.Log(drop.value.ToString());
        switch (drop.value)
        {
            case 1:
                // Debug.Log("MCQ");
                currentQuestion = Instantiate(questionObject, content.transform);
                currentQuestion.GetComponent<QuestionScript>().questionType = TypeOfQuestion.MultipleChoice;
                dropdownButton.SetActive(false);
                break;

            case 2:
                // Debug.Log("Label");
                currentQuestion = Instantiate(questionObject, content.transform);
                currentQuestion.GetComponent<QuestionScript>().questionType = TypeOfQuestion.Label;
                dropdownButton.SetActive(false);
                GameManager.Instance.ChangeUIPage(UIPages.Label);
                break;

            case 3:
                // Debug.Log("SelectAnatomy");
                currentQuestion = Instantiate(questionObject, content.transform);
                currentQuestion.GetComponent<QuestionScript>().questionType = TypeOfQuestion.SelectAnatomy;
                dropdownButton.SetActive(false);
                GameManager.Instance.ChangeUIPage(UIPages.Label);
                break;

            case 4:
                // Debug.Log("Description");
                currentQuestion = Instantiate(questionObject, content.transform);
                currentQuestion.GetComponent<QuestionScript>().questionType = TypeOfQuestion.Instruction;
                dropdownButton.SetActive(false);
                break;
        }

        if (!queList.Contains(currentQuestion.GetComponent<QuestionScript>()))
        {
            queList.Add(currentQuestion.GetComponent<QuestionScript>());
        }

        drop.value = 0;
        // drop.onValueChanged.AddListener(arg0 => AddNewQuestion());
        // addButton.SetActive(false);
        // Invoke("ActiveButton",.5f);
        saveButton.transform.SetAsLastSibling();
    }

    public void SaveQuiz()
    {
        GameManager.Instance.questionObject.questionBank.Clear();
        foreach (var question in queList)
        {
            QuestionData qd = new QuestionData();
            qd.questionType = question.questionType;
            var objName = GameManager.Instance.model.name.Substring(0, GameManager.Instance.model.name.IndexOf('('));
            qd.objectName = objName;
            qd.question = question.question.transform.GetChild(1).GetComponent<TMP_InputField>().text;
            qd.explanation = question.explaination.transform.GetChild(1).GetComponent<TMP_InputField>().text;

            switch (qd.questionType)
            {
                case TypeOfQuestion.MultipleChoice:
                    for (int i = 0; i < 4; i++)
                    {
                        var a = question.mcqOptions.transform.GetChild(2).GetChild(i).GetChild(1)
                            .GetComponent<TMP_InputField>().text;
                        qd.answers.Add(a);
                        if (question.mcqOptions.transform.GetChild(2).GetChild(i).GetComponent<Toggle>().isOn)
                        {
                            qd.correctAnswer = i;
                        }
                    }

                    break;
                case TypeOfQuestion.Label:
                    var list = question.labelList.transform.GetChild(0).GetChild(0);
                    for (int i = 0; i < list.childCount; i++)
                    {
                        qd.selectedObjectsLabel.Add(list.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text);
                    }

                    break;
                case TypeOfQuestion.SelectAnatomy:
                    var list2 = question.labelList.transform.GetChild(0).GetChild(0);
                    for (int i = 0; i < list2.childCount; i++)
                    {
                        qd.selectedObjects.Add(list2.GetChild(i).GetChild(1).GetComponent<TMP_Text>().text);
                    }

                    break;
            }

            GameManager.Instance.questionObject.questionBank.Add(qd);
        }
    }
}