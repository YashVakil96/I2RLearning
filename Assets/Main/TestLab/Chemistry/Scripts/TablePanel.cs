using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePanel : MonoBehaviour
{
    public GameObject panelTable;

    public void SwitchPanel()
    {
        panelTable.SetActive(!panelTable.activeSelf);
    }
}