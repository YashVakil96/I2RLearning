using UnityEngine;

public class ClearAll : MonoBehaviour
{
    public void Clear()
    {
        foreach (var bond in BondManager.Instance.bonds)
        {
            Destroy(bond.gameObject);
        }
        foreach (var atom in AtomManager.instance._molecules)
        {
            Destroy(atom.gameObject);
        }
        BondManager.Instance.bonds.Clear();
        AtomManager.instance._molecules.Clear();
    }
}
