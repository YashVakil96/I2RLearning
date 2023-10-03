using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestoinScript : MonoBehaviour
{
    public TypeOfQuestion questionType;

    public GameObject mcqOptions;

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
        if (questionType == TypeOfQuestion.MultipleChoice)
        {
            mcqOptions.SetActive(true);
        }
        else
        {
            mcqOptions.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}