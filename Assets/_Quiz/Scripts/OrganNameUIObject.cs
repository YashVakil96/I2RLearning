using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrganNameUIObject : MonoBehaviour
{
    private Camera mainCma;
    public TMP_Text organName;
    public OrganSelector organSelector;

    private void OnEnable()
    {
        mainCma = Camera.main;
        GetComponent<Canvas>().worldCamera = mainCma;
    }

    public void SetOrganName(string name,OrganSelector os)
    {
        organName.text = name;
        organSelector = os;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCma.transform.position);
    }

    public void RemoveThisObject()
    {
        organSelector.RemoveLabel(transform);
    }
}
