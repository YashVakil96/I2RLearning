using TMPro;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static bool IsMoving;

    public static bool IsCreating;

    public static bool IsEditing;

    public static bool createBenzene;

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
    }
}