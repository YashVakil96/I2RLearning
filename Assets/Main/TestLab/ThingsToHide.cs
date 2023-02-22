using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsToHide : MonoBehaviour
{
    public List<GameObject> parts;
    public List<GameObject> texts;
    public List<Material> materialsToFade;
    public Color fade;
    public int cycleState = 0;

    private void Start()
    {
        Hide(cycleState);
    }


    IEnumerator DoAThingOverTime(Material mat, Color start, Color end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
//right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            mat.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }

        mat.color = end; //without this, the value will end at something like 0.9992367
    }

    public void FadeToZero(List<Material> mats, int index)
    {
        StartCoroutine(DoAThingOverTime(mats[index], mats[index].color, new Color(mats[index].color.r,mats[index].color.g,mats[index].color.b,0), 1));

        //set material color alpha to 0
    }

    public void FadeToOne(List<Material> mats, int index)
    {
        StartCoroutine(DoAThingOverTime(mats[index], mats[index].color, new Color(mats[index].color.r,mats[index].color.g,mats[index].color.b,1), 1));
        //set material color alpha to 1
    }
    

    public void Next()
    {
        if (cycleState == parts.Count - 1)
        {
            return;
        }
        else
        {
            cycleState++;
            Hide(cycleState);
        }
    }
    
    

    public void Prev()
    {
        if (cycleState == 0)
        {
            return;
        }
        else
        {
            cycleState--;
            Hide(cycleState);
        }
    }

    public void Hide(int index)
    {
        foreach (var part in parts)
        {
            if (part != parts[index])
            {
                part.SetActive(false);
            }
            else
            {
                part.SetActive(true);
            }
        }

        foreach (var part in texts)
        {
            if (part != texts[index])
            {
                part.SetActive(false);
            }
            else
            {
                part.SetActive(true);
            }
        }
    }
}