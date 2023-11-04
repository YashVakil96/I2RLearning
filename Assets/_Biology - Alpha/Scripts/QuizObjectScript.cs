using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizObjectScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject quizPanel;

    private void OnEnable()
    {
        quizPanel.SetActive(true);
    }

    private void OnDisable()
    {
        quizPanel.SetActive(false);
    }
}
