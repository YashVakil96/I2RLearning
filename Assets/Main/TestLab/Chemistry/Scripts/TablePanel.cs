using UnityEngine;

public class TablePanel : MonoBehaviour
{
    public GameObject panelTable;
    public static TablePanel instance;


    private void Awake()
    {
        instance = this;
    }

    public  void SwitchPanel()
    {
        panelTable.SetActive(!panelTable.activeSelf);
    }
    
    
}