using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManager : SerializedMonoBehaviour
{
    #region Public Variables

    [HideInInspector]
    public static GameManager Instance;
    
    public bool forStudent = false;
    public UIPages currentSelectedPage = UIPages.Select;
    public Transform modelObjTransform;
    public GameObject model;
    public SelectObjectScript SelectObjectScriptRef;
    public PaintObjectScript PaintObjectScriptRef;
    public LabelObjectScript LabelObjectScriptRef;
    public QuizObjectScript QuizObjectScriptRef;

    #endregion

    #region Private Variables

    

    #endregion

    #region Unity Classes

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        LoadSelectedObject("SkinCell");
    }

    private void OnEnable()
    {
        ChangeUIPage(UIPages.Select);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeUIPage(UIPages.Select);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeUIPage(UIPages.Paint);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeUIPage(UIPages.Label);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeUIPage(UIPages.Quiz);
        }
    }

    #endregion

    #region Public Methods

    public void LoadSelectedObject(string objName)
    {
        var obj = Resources.Load("Models/" + objName) as GameObject;
        model = Instantiate(obj, Vector3.zero, Quaternion.identity, modelObjTransform);
    }

    public void ChangeUIPage(UIPages page)
    {
        SelectObjectScriptRef.enabled = false;
        LabelObjectScriptRef.enabled = false;
        PaintObjectScriptRef.enabled = false;
        QuizObjectScriptRef.enabled = false;

        switch (page)
        {
            case UIPages.Select:
                SelectObjectScriptRef.enabled = true;
                break;
            case UIPages.Label:
                LabelObjectScriptRef.enabled = true;
                break;
            case UIPages.Paint:
                PaintObjectScriptRef.enabled = true;
                break;
            case UIPages.Quiz:
                QuizObjectScriptRef.enabled = true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(page), page, null);
        }
        
        currentSelectedPage = page;
    }

    #endregion
    
    #region Private Methods

     

    #endregion
}
