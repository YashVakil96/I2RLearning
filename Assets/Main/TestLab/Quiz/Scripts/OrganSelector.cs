using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganSelector : MonoBehaviour
{
    private Camera mainCam;
    public List<GameObject> listOfSelectedOrgans = new List<GameObject>();
    public List<Transform> listOfAddedLabelPoints = new List<Transform>();
    public GameObject uiPrefab;
    private void OnEnable()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.name);
                if (listOfSelectedOrgans.Contains(hit.transform.gameObject))
                {
                    return;
                }
                listOfSelectedOrgans.Add(hit.transform.gameObject);
                var point = Instantiate(uiPrefab, hit.point, Quaternion.identity);
                point.transform.position += new Vector3(0,0,-0.1f);
                point.name = hit.transform.gameObject.name;
                point.transform.SetParent(hit.transform,true);
                point.transform.GetComponent<OrganNameUIObject>().SetOrganName(point.name,this);
                // var point2 = Instantiate(, hit.point, Quaternion.identity);
                listOfAddedLabelPoints.Add(point.transform);
            }
        }
    }

    public void RemoveLabel(Transform t)
    {
        listOfSelectedOrgans.Remove(t.parent.gameObject);
        listOfAddedLabelPoints.Remove(t);
        Destroy(t.gameObject);
    }
}
