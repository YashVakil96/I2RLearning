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
            Debug.Log(mat.name);
        }

        mat.color = end; //without this, the value will end at something like 0.9992367
    }

    public void FadeToZero(Material mats)
    {
        Debug.Log("Hide");
        StartCoroutine(DoAThingOverTime(mats, mats.color,
            new Color(mats.color.r, mats.color.g, mats.color.b, 0), 1));

        //set material color alpha to 0
    }

    public void FadeToOne(Material mats)
    {
        Debug.Log("Show");
        StartCoroutine(DoAThingOverTime(mats, mats.color,
            new Color(mats.color.r, mats.color.g, mats.color.b, 1), 1));
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
                foreach (var mat in part.transform.GetChild(0).GetComponent<MeshRenderer>().materials)
                {
                    FadeToZero(mat);
                }
                // part.SetActive(false);
            }
            else
            {
                foreach (var mat in part.transform.GetChild(0).GetComponent<MeshRenderer>().materials)
                {
                    FadeToOne(mat);
                }
                // part.SetActive(true);
            }
        }

        //text
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