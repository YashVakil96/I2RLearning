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

    private void Awake()
    {
        SetClick();
    }

    public void SetClick()
    {
        foreach (var button in buttonImages)
        {
            Debug.Log(button.GetComponent<MoleculeButton>().buttonMoleculeType);
            button.GetComponent<Button>().onClick
                .AddListener(button.GetComponent<MoleculeButton>().CurrentMoleculeType);
        }
    }
}