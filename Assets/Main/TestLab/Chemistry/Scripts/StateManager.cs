using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public bool IsMoving;
    public bool IsCreating;
    public bool IsEditing;
    public bool createBenzene;
    public bool IsDeleting;

    public static StateManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartMoving()
    {
        StopAll();
        IsMoving = true;
    }

    public void StartCreating()
    {
        StopAll();
        IsCreating = true;
    }

    public void StartEditing()
    {
        StopAll();
        IsEditing = true;
    }

    public void StartBenzene()
    {
        StopAll();
        createBenzene = true;
    }

    public void StartDelete()
    {
        StopAll();
        IsDeleting = true;
    }

    public void OnAnimate()
    {
        MoleculeManager.instance.CreateBonds();
        BondManager.Instance.RemoveBonds();
    }


    public void StopAll()
    {
        IsMoving = false;
        IsCreating = false;
        IsEditing = false;
        createBenzene = false;
        IsDeleting = false;
    }
}