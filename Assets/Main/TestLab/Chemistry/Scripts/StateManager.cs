using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static bool IsMoving;

    public static bool IsCreating;

    public void StartMoving()
    {
        IsMoving = true;
        IsCreating = false;
    }

    public void StartCreating()
    {
        IsMoving = false;
        IsCreating = true;
    }
}