using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideUIObject : MonoBehaviour
{

    public Sprite onSprite;
    public Sprite offSprite;

    public Image showHideImage;
    public TMP_Text partNameText;
    public GameObject part;

    public bool isShowing;

    public void ShowHide()
    {
        if (isShowing)
        {
            isShowing = false;
            showHideImage.sprite = offSprite;
            part.SetActive(false);
        }
        else
        {
            isShowing = true;
            showHideImage.sprite = onSprite;
            part.SetActive(true);
        }
    }

    public void ForceShow()
    {
        isShowing = true;
        showHideImage.sprite = onSprite;
        part.SetActive(true);
    }

    private void OnEnable()
    {
        ForceShow();
    }
}
