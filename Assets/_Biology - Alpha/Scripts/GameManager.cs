using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

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
    public HideObjectScript HideObjectScript;
    public PaintObjectScript PaintObjectScriptRef;
    public LabelObjectScript LabelObjectScriptRef;
    public QuizObjectScript QuizObjectScriptRef;
    public List<string> labelObjects;
    public AddQuestion addQuestion;
    public QuestionBankScriptableObjectScript questionObject;
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
        EnableCam.Instance.CanRotateCamera();
        LoadSelectedObject(PlayerPrefs.GetString("ObjectToLoad", "SkinCell"));
        UIManager.Instance.bottomHudScript.Selection();
        HideObjectScript.Init();
    }

    private void OnEnable()
    {
        ChangeUIPage(UIPages.Select);
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     ChangeUIPage(UIPages.Select);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     ChangeUIPage(UIPages.Paint);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     ChangeUIPage(UIPages.Label);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha4))
        // {
        //     ChangeUIPage(UIPages.Quiz);
        // }
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
        HideObjectScript.enabled = false;
        LabelObjectScriptRef.enabled = false;
        PaintObjectScriptRef.enabled = false;
        
        if (!UIManager.Instance.bottomHudScript.quizOn)
        {
            QuizObjectScriptRef.enabled = false;
        }

        switch (page)
        {
            case UIPages.Select:
                SelectObjectScriptRef.enabled = true;
                break;
            case UIPages.Hide:
                HideObjectScript.enabled = true;
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
