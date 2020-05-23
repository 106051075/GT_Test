using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyNumber : MonoBehaviour
{
    public static int a;

    void Update()
    {
        if(Energy.energyClick1 == true)
        {
            a += 1;
            GetComponent<Text>().text = "" + a;
            Energy.energyClick1 = false;
        }
        if(Energy.energyClick2 == true)
        {
            a -= 1;
            GetComponent<Text>().text = "" + a;
            Energy.energyClick2 = false;
        }
    }
}
