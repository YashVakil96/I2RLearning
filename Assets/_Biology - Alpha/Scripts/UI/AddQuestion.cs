using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddQuestion : MonoBehaviour
{
    public GameObject addQuestionButton;
    public GameObject questionObject;
    public GameObject content;
    public GameObject addButton;

    private void Awake()
    {
        addButton = Instantiate(addQuestionButton,content.transform);
        addButton.transform.GetChild(0).GetComponent<Button>().onClick.AddListener((() => AddNewQuestion()));
    }

    public void AddNewQuestion()
    {
        /*
         * instantiate the question object in the heirarchy
         * move the addQuestion button to below
         */

        Instantiate(questionObject,content.transform);
        addButton.transform.SetAsLastSibling();
    }
}
