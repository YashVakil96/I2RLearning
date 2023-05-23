using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Place : MonoBehaviour
{
    public List<Image> buttonImages;
    public List<Sprite> images;
    
    [ContextMenu("set")]
    public void SetImages()
    {
        for (int i = 0; i < buttonImages.Count; i++)
        {
            buttonImages[i].sprite = images[i];
        }
    }
}
