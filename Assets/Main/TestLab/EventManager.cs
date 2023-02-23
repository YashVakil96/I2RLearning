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

    public void Man()
    {
        Debug.Log("State Man");
    }

    public void Inside()
    {
        Debug.Log("Inside");
    }

    public void AntiBody()
    {
        Debug.Log("Antibody");
    }

    public void HIV()
    {
        Debug.Log("HIV");
    }

    public void CD4()
    {
        Debug.Log("CD4");
    }

    public void VirusMed()
    {
        Debug.Log("Virus Med");
    }


    public void JumpToEvent(int enumState)
    {
        switch ((State)enumState)
        {
            case State.Man:
                Man();
                break;

            case State.Inside:
                Inside();
                break;

            case State.Antibody:
                AntiBody();
                break;
            case State.HIV:
                HIV();
                break;

            case State.CD4:
                CD4();
                break;
            
            case  State.VirusMed:
                VirusMed();
                break;
        }
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