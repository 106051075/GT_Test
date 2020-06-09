using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Rope : MonoBehaviour
{
    int crystal;
    private int energyValue;
    private LineRenderer LR;
    private int LengthOfLineRenderer = 30;
    bool touch = false;
    private float time = 0;
    bool isOver = false;



    private void Start()
    {
        crystal = LayerMask.NameToLayer("crystal");
        energyValue = 1;
        LR = GetComponent<LineRenderer>();
        LR.positionCount = LengthOfLineRenderer;
    }

    private void OnMouseOver()
    {
        isOver= true;
        print("click");
    }

    private void OnMouseExit()
    {
        isOver = false;
    }

    private void Update()
    {
        isOn();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (other.gameObject.layer == crystal)
        {
          touch = true;
            print("touch");
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.layer == crystal && Input.GetMouseButtonUp(1) && energyValue == 0)
        {

        }
    }

    private void isOn()
    {
        if (touch == true)
        {
            if(isOver == true)
            {
                if (Input.GetMouseButtonDown(0) && EnergyNumber.a <= 4 && EnergyNumber.a >= 0 && energyValue == 1)
                {
                    energyValue -= 1;
                    LR.positionCount -= 1;
                    if (LR.positionCount <= 15)
                    {
                        touch = false;
                    }
                }
            }
        }
    }
}


