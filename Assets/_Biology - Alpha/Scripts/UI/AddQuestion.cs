using System;
using System.Collections.Generic;
using TMPro;
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
    }

    public void ActiveButton()
    {
        // addButton.SetActive(true);
        // addButton.transform.SetAsLastSibling();
    }
}