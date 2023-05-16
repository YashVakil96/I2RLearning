using System;
using UnityEngine;
public class LineContainer : MonoBehaviour
{
    public LineRenderer line;
    public Vector3 startPos;
    public Vector3 endPose;
    public bool markedToDelete;

    public void SetValues(LineRenderer lineRenderer,Vector3 start , Vector3 end)
    {
        line = lineRenderer;
        startPos = start;
        endPose = end;
    }

    private void Start()
    {

        if (CalculateDistance()<.01f)
        {
            Destroy(this);
        }
    }
    
    private float CalculateDistance()
    {
        Vector3 startPoint = line.GetPosition(0);
        Vector3 endPoint = line.GetPosition(1);

        float distance = Vector3.Distance(startPoint, endPoint);
        return distance;
    }

    private void OnDestroy()
    {
        BondManager.Instance.bonds.Remove(line);
    }
}
