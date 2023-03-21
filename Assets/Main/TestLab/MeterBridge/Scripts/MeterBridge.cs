using System;
using UnityEngine;
using UnityEngine.UI;

public class MeterBridge : MonoBehaviour
{
    public static MeterBridge Instance;
    public double resistanceBoxPower;
    public double registerPower;
    public double l;
    public double hundredMinusL;
    public double finalL;
    public double finalRes;
    public GameObject movePenButton;

    private void Awake()
    {
        Instance = this;
    }


    public void Calculate()
    {
        EventManagerMeterBridge.Instance.register.text = registerPower.ToString();
        if (l > finalL)
        {
            l = finalL;
            EventManagerMeterBridge.Instance.l.text = l.ToString();
        }
        else
        {
            EventManagerMeterBridge.Instance.l.text = l.ToString();
        }

        EventManagerMeterBridge.Instance.HunderedMinusL.text = hundredMinusL.ToString();
    }

    public double HunderedMinusL(double l)
    {
        return 100 - l;
    }

    [ContextMenu("find")]
    public void FindL()
    {
        for (float i = 0; i <= 100; i += 0.01F)
        {
            if (registerPower <= resistanceBoxPower * (i / HunderedMinusL(i)) + 0.1f &&
                registerPower >= resistanceBoxPower * (i / HunderedMinusL(i)) - 0.1f)
            {
                Debug.Log(i + " Found it");
                var newi = Math.Round(i, 1);
                Debug.Log(newi + " New I");
                finalRes = resistanceBoxPower * (i / HunderedMinusL(i));
                finalL = newi;
                break;
            }
        }

        // float ans;
        // float rr = resistanceBoxPower / registerPower;
        /*
         R=100 , S = 100 
        So R/S = 1...
        So main formula
        1 = l/100-l..
        100-l = l..
        100= l+l..
        100= 2l..
        100/2= l..
        50= l..
         */
        movePenButton.SetActive(EventManagerMeterBridge.Instance.isItOn);
    }
}