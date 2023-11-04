using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UndoRedo : MonoBehaviour
{
    public static UndoRedo Instance;
    
    public int undoCount;
    public List<GameObject> undoSelectedObject;
    public List<GameObject> redoSelectedObject;

    public Button undoButton;
    public Button redoButton;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance== null)
        {
            Instance = this;
        }
        UndoButtonInteractable();
        RedoButtonInteractable();
    }


    [Button(ButtonSizes.Small,ButtonStyle.Box,Name = "Undo")]
    public void Undo()
    {
        GameManager.Instance.SelectObjectScriptRef.DeSelectObject();
        int a;
        a = undoSelectedObject.Count - 1;
        GameManager.Instance.SelectObjectScriptRef.Selection(undoSelectedObject[a]);
        redoSelectedObject.Add(undoSelectedObject[a]);
        if (undoSelectedObject.Count<1)
        {
            undoSelectedObject.Clear();
        }
        else
        {
            undoSelectedObject.RemoveAt(a);
        }

        UndoButtonInteractable();
        RedoButtonInteractable();
    }
    [Button(ButtonSizes.Small,ButtonStyle.Box,Name = "Redo")]
    public void Redo()
    {
        GameManager.Instance.SelectObjectScriptRef.DeSelectObject();
        int a;
        if (redoSelectedObject.Count ==1)
        {
            a = redoSelectedObject.Count;
        }
        else
        {
            a = redoSelectedObject.Count - 2;        
        } 
        GameManager.Instance.SelectObjectScriptRef.Selection(redoSelectedObject[a]);
        // redoSelectedObject.Add(redoSelectedObject[a]);
        if (redoSelectedObject.Count<3)
        {
            redoSelectedObject.Clear();
        }
        else
        {
            redoSelectedObject.RemoveAt(a);
        }

        RedoButtonInteractable();
    }
     
    public void UndoButtonInteractable()
    {
        undoButton.interactable = undoSelectedObject.Count > 0;
    }
    public void RedoButtonInteractable()
    {
        redoButton.interactable = redoSelectedObject.Count > 0;
    }
}