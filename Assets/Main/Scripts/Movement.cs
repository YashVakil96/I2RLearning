using DG.Tweening;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 pos;
    void Start()
    {
        transform.DOMove(pos, 0.5f).SetLoops(-1, LoopType.Yoyo);
        
    }
}
