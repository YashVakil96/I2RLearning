using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public bool moveState;
    public bool createState;
    public bool editState;
    public bool createBenzene;
    public CurrentState currentState;

    public static StateManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartMoving()
    {
        StopAll();
        moveState = true;
    }

    public void StartCreating()
    {
        StopAll();
        createState = true;
    }

    public void StartEditing()
    {
        currentState = CurrentState.EditState;
    }

    public void StartBenzene()
    {
        StopAll();
        createBenzene = true;
    }
    public void StartDelete()
    {
        currentState = CurrentState.DeleteState;
    }

    public void OnAnimate()
    {
        BondManager.Instance.AnimateBonds();
        BondManager.Instance.RemoveBonds();
    }


    public void StopAll()
    {
        moveState = false;
        createState = false;
        editState = false;
        createBenzene = false;
    }

    public enum CurrentState
    {
        MoveState,
        CreateState,
        EditState,
        DeleteState
    }
}