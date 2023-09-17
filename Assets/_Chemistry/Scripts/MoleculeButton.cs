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

        StateManager.Instance.currentState = StateManager.CurrentState.CreateState;

        /*StateManager.Instance.StopAll();
        StateManager.Instance.createState = true;*/

        CheckOnCanvas.OnCanvasBool = false;
    }
}