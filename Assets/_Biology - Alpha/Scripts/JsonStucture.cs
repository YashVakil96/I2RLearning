using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonStucture
{
    
}

public class SelectedObject
{
    public GameObject selectedObject;
    public Vector3 selectedPoint;
}

public enum UIPages
{
    Select,
    Label,
    Paint,
    Quiz
}

public enum QuizQuestionType
{
    MultipleChoice,
    SelectAnatomy,
    Label,
    Instruction
}
