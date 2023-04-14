using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeManager : MonoBehaviour
{
    public static MoleculeManager instance;
    public List<Molecule> _molecules;

    private void Awake()
    {
        instance = this;
    }
}
