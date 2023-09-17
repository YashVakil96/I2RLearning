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