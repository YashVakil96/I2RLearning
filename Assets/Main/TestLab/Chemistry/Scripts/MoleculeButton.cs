using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeButton : MonoBehaviour
{
    public MolecuteType buttonMoleculeType;

    public void CurrentMoleculeType()
    {
        MoleculeAssigner.CurrentMoleculeType = buttonMoleculeType;
    }
}
