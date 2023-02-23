using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public State state;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        state = State.Man;
    }

    public enum State
    {
        Man = 0,
        Inside = 1,
        Antibody = 2,
        HIV = 3,
        CD4 = 4,
        VirusMed = 5
    }
}