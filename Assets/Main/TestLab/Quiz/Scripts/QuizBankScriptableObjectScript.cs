using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Bank", menuName = "ScriptableObjects/Quiz Bank", order = 1)]
public class QuizBankScriptableObjectScript : ScriptableObject
{
    public List<QuestionBankScriptableObjectScript> quiz;
}
