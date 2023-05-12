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
}
