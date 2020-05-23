using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    int crystal;
    public static bool energyClick1 = false;
    public static bool energyClick2 = false;

    private void Start()
    {
        crystal = LayerMask.NameToLayer("crystal");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == crystal && Input.GetMouseButtonDown(0) && EnergyNumber.a <= 5 && EnergyNumber.a >= 0)
        {
            energyClick1 = true;
            transform.localScale = new Vector2(transform.localScale.x / 2, transform.localScale.y / 2);
        }
        if (other.gameObject.layer == crystal && Input.GetMouseButtonDown(1) && EnergyNumber.a >= 1 && EnergyNumber.a <= 5) 
        {
            energyClick2 = true;
            transform.localScale = new Vector2(transform.localScale.x * 2, transform.localScale.y * 2);
        }
    }

}
