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
        MolecuteType = MoleculeAssigner.CurrentMoleculeType;
        name = MolecuteType.ToString();
        MoleculeManager.instance._molecules.Add(this);
    }
    
    
}

public enum MolecuteType
{
    C,H,N,O,P,S,F,CL,BR,I
}