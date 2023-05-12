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

    public List<GameObject> moleculeNames;

    private void Awake()
    {
        MolecuteType = MoleculeAssigner.CurrentMoleculeType;
        name = MolecuteType.ToString();
        MoleculeManager.instance._molecules.Add(this);
        
        SetMoleculeName(MolecuteType);
    }


    public void SetMoleculeName(MolecuteType molType)
    {
        foreach (var mol in moleculeNames)
        {
            if (mol.name.Equals(molType.ToString()) )
            {
                mol.SetActive(true);
            }
        }
    }
    
}

public enum MolecuteType
{
    C,H,N,O,P,S,F,CL,BR,I
}