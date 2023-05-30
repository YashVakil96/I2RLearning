using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[ExecuteInEditMode]
public class Molecule : MonoBehaviour
{
    public MolecuteType MolecuteType;
    public bool currentlySelected;
    public int NoOfBonds;

    public List<LineRenderer> bonds;
    public List<int> index;

    public List<GameObject> moleculeNames;
    public Sprite testSprite;

    private void Awake()
    {
        MolecuteType = MoleculeAssigner.CurrentMoleculeType;
        name = MolecuteType.ToString();
        AtomManager.instance._molecules.Add(this);

        SetMoleculeName(MolecuteType);
    }


    public void SetMoleculeName(MolecuteType molType)
    {
        foreach (var mol in moleculeNames)
        {
            if (mol.name.Equals(molType.ToString()))
            {
                mol.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        AtomManager.instance._molecules.Remove(this);
    }

    /*[ContextMenu("CreateObj")]
    public void CreateObjects()
    {
        foreach (var atom in Enum.GetNames(typeof(MolecuteType)))
        {
            var newobj = new GameObject(atom);
            newobj.transform.parent = transform;
            if (atom.Length > 1)
            {
                GameObject image1 = new GameObject();
                image1.AddComponent<SpriteRenderer>();
                image1.transform.parent = newobj.transform;
                image1.GetComponent<SpriteRenderer>().sortingOrder = 11;
                
                GameObject image2 = new GameObject();
                image2.AddComponent<SpriteRenderer>();
                image2.transform.parent = newobj.transform;
                image2.GetComponent<SpriteRenderer>().sortingOrder = 11;
                
                image1.transform.localScale = Vector3.one * 0.4f;
                image2.transform.localScale = Vector3.one * 0.4f;
                
                image1.transform.position = new Vector3(-0.2f,0,0);
                image2.transform.position = new Vector3(0.2f,0,0);

                image1.GetComponent<SpriteRenderer>().sprite = testSprite;
                image2.GetComponent<SpriteRenderer>().sprite = testSprite;
            }
            else
            {
                newobj.AddComponent<SpriteRenderer>();
                newobj.GetComponent<SpriteRenderer>().sortingOrder = 11;
                newobj.transform.localScale = Vector3.one * 0.5f;
                newobj .GetComponent<SpriteRenderer>().sprite = testSprite;
            }
        }
    }*/
}

public enum MolecuteType
{
    H,
    He,
    Li,
    Be,
    B,
    C,
    N,
    O,
    F,
    Ne,
    Na,
    Mg,
    Al,
    Si,
    P,
    S,
    Cl,
    Ar,
    K,
    Ca,
    Sc,
    Ti,
    V,
    Cr,
    Mn,
    Fe,
    Co,
    Ni,
    Cu,
    Zn,
    Ga,
    Ge,
    As,
    Se,
    Br,
    Kr,
    Rb,
    Sr,
    Y,
    Zr,
    Nb,
    Mo,
    Tc,
    Ru,
    Rh,
    Pd,
    Ag,
    Cd,
    In,
    Sn,
    Sb,
    Te,
    I,
    Xe,
    Cs,
    Ba,
    La,
    Ce,
    Pr,
    Nd,
    Pm,
    Sm,
    Eu,
    Gd,
    Tb,
    Dy,
    Ho,
    Er,
    Tm,
    Yb,
    Lu,
    Hf,
    Ta,
    W,
    Re,
    Os,
    Ir,
    Pt,
    Au,
    Hg,
    Tl,
    Pb,
    Bi,
    Po,
    At,
    Rn,
    Fr,
    Ra,
    Ac,
    Th,
    Pa,
    U,
    Np,
    Pu,
    Am,
    Cm,
    Bk,
    Cf,
    Es,
    Fm,
    Md,
    No,
    Lr,
    Rf,
    Db,
    Sg,
    Bh,
    Hs,
    Mt,
    Ds,
    Rg,
    Cn,
    Nh,
    Fl,
    Mc,
    Lv,
    Ts,
    Og
}