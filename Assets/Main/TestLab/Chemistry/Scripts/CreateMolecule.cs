using Unity.Mathematics;
using UnityEngine;

public class CreateMolecule : MonoBehaviour
{
    public GameObject molecule;
    public float raycastDistance = 1f; // Distance to cast the rays
    public float spawnDistance = 2f; // Distance to spawn the new object

    public void Create()
    {
        var a = Instantiate(molecule,
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5)),
            quaternion.identity);
        a.tag = "Molecule";
    }
}