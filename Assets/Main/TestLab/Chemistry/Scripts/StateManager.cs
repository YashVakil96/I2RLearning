using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static bool IsMoving;

    public static bool IsCreating;
    
    public static bool IsEditing;

    public void StartMoving()
    {
        IsMoving = true;
        IsCreating = false;
        IsEditing = false;
    }

    public void StartCreating()
    {
        IsCreating = true;
        IsMoving = false;
        IsEditing = false;
    }
    public void StartEditing()
    {
        IsEditing = true;
        IsCreating = false;
        IsMoving = false;
    }

    public void OnAnimate()
    {
        MoleculeManager.instance.CreateBonds();
        BondManager.Instance.RemoveBonds();
    }
    
}