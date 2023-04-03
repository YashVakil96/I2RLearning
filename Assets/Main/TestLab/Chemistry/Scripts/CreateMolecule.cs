using Unity.Mathematics;
using UnityEngine;

public class CreateMolecule : MonoBehaviour
{
    public GameObject molecule;

    public void Create()
    {
        var a = Instantiate(molecule,
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)),
            quaternion.identity);
        a.transform.position = new Vector3(a.transform.position.x, a.transform.position.y, 0);
    }
}