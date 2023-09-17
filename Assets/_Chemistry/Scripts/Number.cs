using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Number : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 15;
        transform.DOScale(.1f, 0.5f);
    }
}
