using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Question Bank", menuName = "ScriptableObjects/Question Bank", order = 1)]
public class QuestionBankScriptableObjectScript : ScriptableObject
{
    public List<QuestionData> questionBank;
}

[Serializable]
public class QuestionData
{

    public string quizName;
    [EnumToggleButtons] public TypeOfQuestion questionType;

    [HideIf("questionType", TypeOfQuestion.Instruction)]
    public string question;

    [HideIf("questionType", TypeOfQuestion.Instruction)] [Multiline(4)]
    public string explanation;

    public Transform questionCamPos; //starting Camera Position and Rotation

    //MCQ
    [ShowIf("questionType", TypeOfQuestion.MultipleChoice)]
    public List<string> answers = new List<string>();

    [ShowIf("questionType", TypeOfQuestion.MultipleChoice)]
    public int correctAnswer;

    //Select Anatomy
    [ShowIf("questionType", TypeOfQuestion.SelectAnatomy)]
    public List<string> selectedObjects = new List<string>();

    //Label
    [ShowIf("questionType", TypeOfQuestion.Label)]
    public List<string> selectedObjectsLabel = new List<string>();

    //instruction same as Question String
    [ShowIf("questionType", TypeOfQuestion.Instruction)] [Multiline(4)]
    public string instruction;
}

public enum TypeOfQuestion
{
    MultipleChoice,
    SelectAnatomy,
    Label,
    Instruction
}