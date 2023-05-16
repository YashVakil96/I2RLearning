using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CreateShapes : MonoBehaviour
{

    public GameObject benzene;
    // Update is called once per frame
    void Update()
    {
        if (StateManager.createBenzene)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBenzene();
            }
        }
    }
    
    public void PlaceBenzene()
    {
        var a = Instantiate(benzene,
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)),
            quaternion.identity);
    }
}