using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabRope : MonoBehaviour
{
    [SerializeField] private string selectableTag = "vine";
    HingeJoint2D playerJoint;
    public GameObject Target;
    bool isTouching = false;

    // Start is called before the first frame update
    void Start()
    {
        playerJoint = Target.GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        connect();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(selectableTag))
        {
            isTouching = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    void connect()
    {
        if(isTouching == true)
        {
            
        }
    }
}
