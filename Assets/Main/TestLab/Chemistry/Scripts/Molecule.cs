using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Molecule : MonoBehaviour
{
    public MolecuteType MolecuteType;
    public bool currentlySelected;

    private void Awake()
    {
        name = MolecuteType.ToString();
    }
}


public enum MolecuteType
{
    a,
    b,
    c,
    d
}