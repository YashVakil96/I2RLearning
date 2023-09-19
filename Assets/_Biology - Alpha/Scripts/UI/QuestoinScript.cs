using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestoinScript : MonoBehaviour
{
    public TypeOfQuestion questionType;

    public GameObject mcqOptions;

    // Start is called before the first frame update
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