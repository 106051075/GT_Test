using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vine : MonoBehaviour
{
    public GameObject Target;
    public int LengthOfLineRenderer = 30;
    bool isTouch = false;
    bool isOver = false;
    int hp;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lr = Target.GetComponent<LineRenderer>();
        hp = 1;
    }

    private void OnMouseOver()
    {
        if(gameObject.CompareTag("vine"))
        {
            isOver = true;
        }
    }
    private void OnMouseExit()
    {
        if (gameObject.CompareTag("vine"))
        {
            isOver = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lr = Target.GetComponent<LineRenderer>();
        lr.positionCount = LengthOfLineRenderer;
        if(isOver == true)
        {
            if (isTouch == true)
            {
                if (Input.GetMouseButtonDown(0) && EnergyNumber.a <= 4 && EnergyNumber.a >= 0 && hp == 1)
                {
                    hp -= 1;
                    Energy.energyClick1 = true;
                }
                if (Input.GetMouseButtonDown(1) && EnergyNumber.a <= 5 && EnergyNumber.a >= 1 && hp == 0)
                {
                    hp += 1;
                    Energy.energyClick2 = true;
                }
            }
        }
        if (hp == 0)
        {
            StartCoroutine("Diminishing");
            if (LengthOfLineRenderer == 15)
            {
                StopCoroutine("Diminishing");
                isTouch = false;
            }
        }
        if(hp == 1)
        {
            StartCoroutine("Increment");
            if(LengthOfLineRenderer == 30)
            {
                StopCoroutine("Increment");
                isTouch = false;
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        LineRenderer lr = Target.GetComponent<LineRenderer>();
        lr.positionCount = LengthOfLineRenderer;
        if (other.gameObject.tag == "vine")
        {
            isTouch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "vine" && hp == 0)
        {
            isTouch = false;
        }
    }

    private IEnumerator Diminishing()
    {
        LineRenderer lr = Target.GetComponent<LineRenderer>();
        lr.positionCount = LengthOfLineRenderer;
        while(LengthOfLineRenderer >= 16)
        {
            LengthOfLineRenderer--;
            Debug.Log(LengthOfLineRenderer);
            yield return new WaitForSeconds(speed);
        }
        yield break;
    }

    private IEnumerator Increment()
    {
        LineRenderer lr = Target.GetComponent<LineRenderer>();
        lr.positionCount = LengthOfLineRenderer;
        while(LengthOfLineRenderer <= 29)
        {
            LengthOfLineRenderer++;
            Debug.Log(LengthOfLineRenderer);
            yield return new WaitForSeconds(speed);
        }
        yield break;
    }
}
