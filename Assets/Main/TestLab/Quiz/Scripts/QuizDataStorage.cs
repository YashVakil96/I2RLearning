using System;
using System.Collections.Generic;
using UnityEngine;

public class QuizDataStorage : MonoBehaviour
{
    public List<QuestionData> questionBank;
}

[Serializable]
public class QuestionData
{
    public TypeOfQuestion questionType;
    public string question;
    public string option1; // For MultipleChoice questions
    public string option2; // For MultipleChoice questions
    public string option3; // For MultipleChoice questions
    public string option4; // For MultipleChoice questions
}

public enum TypeOfQuestion
{
    Label,
    SelectAnatomy,
    Description,
    MultipleChoice
}