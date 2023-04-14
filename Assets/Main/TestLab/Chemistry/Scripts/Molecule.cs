using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Molecule : MonoBehaviour
{
    public MolecuteType MolecuteType;
    public bool currentlySelected;
    public int NoOfBonds;
    
    public List<LineRenderer> bonds;
    public List<int> index;

    private void Awake()
    {
        name = MolecuteType.ToString();
        MoleculeManager.instance._molecules.Add(this);
    }
}

public enum MolecuteType
{
    a,
    b,
    c,
    d
}