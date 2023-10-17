using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject showHidePrefab;
    public GameObject showHidePanel;
    public Transform content;
    private GameObject model;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        model = GameManager.Instance.model;
        for (int i = 0; i < model.transform.childCount; i++)
        {
            var temp = Instantiate(showHidePrefab, content);
            temp.GetComponent<ShowHideUIObject>().partNameText.text = model.transform.GetChild(i).name;
            temp.GetComponent<ShowHideUIObject>().part = model.transform.GetChild(i).gameObject;
        }

        showHidePanel.SetActive(true);
    }

    private void OnEnable()
    {
        Init();
    }

    public void RevertAll()
    {
        for (int i = 0; i < model.transform.childCount; i++)
        {
            model.transform.GetChild(i).gameObject.SetActive(true);
        }   
        showHidePanel.SetActive(false);
    }
}
