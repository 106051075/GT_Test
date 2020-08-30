using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vine : MonoBehaviour
{
    [SerializeField] private string selectableTag = "vine";
    public GameObject Target;
    public int LengthOfLineRenderer = 8;
    bool isTouch = false;
    public int hp;
    public float speed;
    bool isTouchingRope = false;

    [Header("hide")]
    public Collider2D c5;
    public Collider2D c6;
    public Collider2D c7;
    public Collider2D c8;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lr = Target.GetComponent<LineRenderer>();
        hp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lr = Target.GetComponent<LineRenderer>();
        lr.positionCount = LengthOfLineRenderer;
        ClickSelect();
        if (isTouchingRope == true)
        {
            if (isTouch == true)
            {
                if (Input.GetMouseButtonDown(0) && EnergyNumber.a <= 4 && EnergyNumber.a >= 0 && hp == 1)
                {
                    hp -= 1;
                    CoreOfLife.Click1 = true;
                }
                if (Input.GetMouseButtonDown(1) && EnergyNumber.a <= 5 && EnergyNumber.a >= 1 && hp == 0)
                {
                    hp += 1;
                    CoreOfLife.Click2 = true;
                }
            }
        }
        if (hp == 0)
        {
            StartCoroutine("Diminishing");
            if (LengthOfLineRenderer == 4)
            {
                StopCoroutine("Diminishing");
                isTouch = false;
            }
            c5.enabled = false;
            c6.enabled = false;
            c7.enabled = false;
            c8.enabled = false;
         }
        if(hp == 1)
        {
            StartCoroutine("Increment");
            if(LengthOfLineRenderer == 8)
            {
                StopCoroutine("Increment");
                isTouch = false;
            }
            c5.enabled = true;
            c6.enabled = true;
            c7.enabled = true;
            c8.enabled = true;
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
        while(LengthOfLineRenderer >= 5)
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
        while(LengthOfLineRenderer <= 7)
        {
            LengthOfLineRenderer++;
            Debug.Log(LengthOfLineRenderer);
            yield return new WaitForSeconds(speed);
        }
        yield break;
    }

    GameObject ClickSelect()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f, LayerMask.GetMask("vine"));
        var selection = hit.transform;
        if (selection.CompareTag(selectableTag))
        {
            isTouchingRope = true;
            return hit.transform.gameObject;
        }
        else
        {
            isTouchingRope = false;
            return null;
        }
    }
}
