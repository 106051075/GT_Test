using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    int crystal;
    public static bool energyClick1 = false;
    public static bool energyClick2 = false;
    public Animator ani;

    private void Start()
    {
        crystal = LayerMask.NameToLayer("crystal");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == crystal && Input.GetMouseButtonDown(0) && EnergyNumber.a <= 4 && EnergyNumber.a >= 0)
        {
            energyClick1 = true;
            ani.SetBool("Click",true);
        }
        if (other.gameObject.layer == crystal && Input.GetMouseButtonDown(1) && EnergyNumber.a >= 1 && EnergyNumber.a <= 4) 
        {
            energyClick2 = true;
            ani.SetBool("Click", false);
        }
    }
}
