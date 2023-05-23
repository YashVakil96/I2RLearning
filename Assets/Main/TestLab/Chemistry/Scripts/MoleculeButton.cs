using UnityEngine;

public class MoleculeButton : MonoBehaviour
{
    public MolecuteType buttonMoleculeType;

    public void CurrentMoleculeType()
    {
        MoleculeAssigner.CurrentMoleculeType = buttonMoleculeType;
    }
}
