using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePlace : MonoBehaviour
{
    public Transform lastBone;

    private void LateUpdate()
    {
        lastBone.position = transform.position;
    }
}
