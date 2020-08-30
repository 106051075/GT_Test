using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class Rope : MonoBehaviour
{
    [SerializeField] private string selectableTag = "vine";
    HingeJoint2D VineJoint;
    public GameObject P_Target;
    public GameObject V_Target;
    bool isToching = false;

    private void Start()
    {
       VineJoint = V_Target.gameObject.AddComponent<HingeJoint2D>();
    }

    private void Update()
    {
        connect();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(selectableTag))
        {
            isToching = true;
            print("isTouch");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(selectableTag))
        {
            isToching = false;
        }
    }

    void connect()
    {
        if(isToching == true)
        {
            if(Input.GetKey(KeyCode.V))
            {
                VineJoint.connectedBody = P_Target.gameObject.GetComponent<Rigidbody2D>();
            }
            if(Input.GetKeyUp(KeyCode.V))
            {
                
            }
        }
    }
}


