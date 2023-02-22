using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsToHide : MonoBehaviour
{
    public List<GameObject> parts;
    public int cycleState = 0;

    private void Start()
    {
        Debug.Log(parts.Count);
        Debug.Log(parts.Capacity);
    }

    public void Next()
    {
        if (cycleState == parts.Count - 1)
        {
            return;
        }
        else
        {
            cycleState++;
            Hide(cycleState);
        }
    }

    public void Prev()
    {
        if (cycleState == 0)
        {
            return;
        }
        else
        {
            cycleState--;
            Hide(cycleState);
        }
    }

    public void Hide(int index)
    {
        foreach (var part in parts)
        {
            if (part != parts[index])
            {
                part.SetActive(false);
            }
            else
            {
                part.SetActive(true);
            }
        }
    }
}