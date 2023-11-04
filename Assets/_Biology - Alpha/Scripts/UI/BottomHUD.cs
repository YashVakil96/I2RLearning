using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BottomHUD : MonoBehaviour
{
    public List<Sprite> activeButtons;
    public List<Sprite> deActiveButtons;
    public Image selectionImage;
    public Image hideImage;
    public Image labelImage;
    public Image paintImage;
    public Image quizImage;

    public bool quizOn;

    public void Selection()
    {
        DeselectAll();
        selectionImage.sprite = activeButtons[0];
        GameManager.Instance.ChangeUIPage(UIPages.Select);
    }

    public void Hide()
    {
        DeselectAll();
        hideImage.sprite = activeButtons[1];
        GameManager.Instance.ChangeUIPage(UIPages.Hide);
    }

    public void Label()
    {
        DeselectAll();
        labelImage.sprite = activeButtons[2];
        GameManager.Instance.ChangeUIPage(UIPages.Label);
    }

    public void Paint()
    {
        DeselectAll();
        paintImage.sprite = activeButtons[3];
        GameManager.Instance.ChangeUIPage(UIPages.Paint);
    }

    public void Quiz()
    {
        DeselectAll();
        quizImage.sprite = activeButtons[4];
        GameManager.Instance.ChangeUIPage(UIPages.Quiz);
        quizOn = true;
    }

    public void DeselectAll()
    {
        selectionImage.sprite = deActiveButtons[0];
        hideImage.sprite = deActiveButtons[1];
        labelImage.sprite = deActiveButtons[2];
        paintImage.sprite = deActiveButtons[3];
        quizImage.sprite = deActiveButtons[4];
        quizOn = false;    
    }
}


