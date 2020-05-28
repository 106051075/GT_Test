using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    int crystal;
    public static bool energyClick1 = false;
    public static bool energyClick2 = false;
    public Animator ani;
    private int hp = 1;

    private void Start()
    {
        crystal = LayerMask.NameToLayer("crystal");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == crystal && Input.GetMouseButtonDown(0) && EnergyNumber.a <= 4 && EnergyNumber.a >= 0 && hp == 1)
        {
            energyClick1 = true;
            ani.SetBool("Click",true);
            hp -= 1;
        }
        if(hp == 0 && Input.GetMouseButtonUp(0))
        {
            energyClick1 = false;
        }
        if (other.gameObject.layer == crystal && Input.GetMouseButtonDown(1) && EnergyNumber.a >= 1 && EnergyNumber.a <= 5 && hp == 0) 
        {
            energyClick2 = true;
            ani.SetBool("Click", false);
            hp += 1;
        }
        if (hp == 1 && Input.GetMouseButtonUp(1))
        {
            energyClick2 = false;
        }
    }
}
