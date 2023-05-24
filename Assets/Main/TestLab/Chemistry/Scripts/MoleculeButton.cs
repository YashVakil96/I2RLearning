using UnityEngine;

public class MoleculeButton : MonoBehaviour
{
    public MolecuteType buttonMoleculeType;


    public void CurrentMoleculeType()
    {
        MoleculeAssigner.CurrentMoleculeType = buttonMoleculeType;
        if (TablePanel.instance.panelTable.activeSelf)
        {
            TablePanel.instance.SwitchPanel();
        }

        StateManager.instance.StopAll();
        StateManager.instance.IsCreating = true;

        CheckOnCanvas.OnCanvasBool = false;
    }
}