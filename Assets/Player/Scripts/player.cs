using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{

    public Animator ani;
    public Transform tran;
    Rigidbody2D rig;
    public float speed = 0.1f;
    public float speed_x_constraint;
    public bool jumpingCheck = false;
    public bool fallingCheck = false;
    public float fallingSpeed;
    public float jumpForce;
    public Animator MotionAnimator;
    public bool FloorCheck = false;
    public bool jumptofallcheck = false;
    public float JumpSpeed = 100f;
    public int RunSpeed;
    public Transform ledgeCheck;
    private bool isTouchingLedge;
    private bool isTouchingWall;
    public Transform wallCheck;
    public float wallCheckDistance;
    public LayerMask whatIsGround;
    private bool canClimbLedge = false;
    private bool ledgeDetected;
    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;
    private Vector2 ledgePos2;
    public float ledgeClimbXOffset1 = 0f;
    public float ledgeClimbYOffset1 = 0f;
    public float ledgeClimbXOffset2 = 0f;
    public float ledgeClimbYOffset2 = 0f;
    public bool isFacingRight = true;

    [Header("Health")]
    public int hp = 4;
    public int maxHp = 4;
    public Material PercentageMat;
    public float health;
    public float maxHealth;

    [Header("Iframe Stuff")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;


    public void Start()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        hp = maxHp;
        maxHp = 4;
        PercentageMat.SetFloat("_Percentage", health / maxHealth);
    }
    void Update()
    {
        walk();
        jump();
        JumpToFall();
        FallingFunction();
        Run();
        CheckLedgeClimb();


        if (rig.velocity.x > speed_x_constraint)
        {
            rig.velocity = new Vector2(speed_x_constraint, rig.velocity.y);
        }
        if (rig.velocity.x < speed_x_constraint)
        {
            rig.velocity = new Vector2(-speed_x_constraint, rig.velocity.y);
        }
        print(rig.velocity);


       
        if(hp == 4)
        {
            health = 0;
            PercentageMat.SetFloat("_Percentage", health / maxHealth);
        }
        if (hp == 3)
        {
            health = 70;
            PercentageMat.SetFloat("_Percentage", health / maxHealth);
        }
        if (hp == 2)
        {
            health = 211;
            PercentageMat.SetFloat("_Percentage", health / maxHealth);
        }
        if (hp == 1)
        {
            health = 285;
            PercentageMat.SetFloat("_Percentage", health / maxHealth);
        }
        if(hp == 0)
        {
            health = 314;
            PercentageMat.SetFloat("_Percentage", health / maxHealth);
        }
    }

    private void FixedUpdate()
    {
        CheckSurroundings();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor")
        {
            FloorCheck = true;
            jumpingCheck = true;
            Debug.Log("Floor");
            MotionAnimator.SetBool("OnFloor", FloorCheck);
        }
        if (other.gameObject.tag == "monster")
        {
            print(other.gameObject.name);
            hp -= 1;
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
            StartCoroutine(FlashCollider());
        }
        if(other.gameObject.tag == "Trampoline")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 25f);
        }
       
    
    }

    void OnCollisionExit2D(Collision2D otherexit)
    { 
        
        if (otherexit.gameObject.tag == "floor")
           {
                FloorCheck = false;
                Debug.Log("OffFloor");
                MotionAnimator.SetBool("OnFloor", FloorCheck);
           }
        
    }

    private void CheckSurroundings()
    {
        isTouchingLedge = Physics2D.Raycast(ledgeCheck.position, transform.right, wallCheckDistance, whatIsGround);

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if(isTouchingWall && !isTouchingLedge && !ledgeDetected)
        {
            ledgeDetected = true;
            ledgePosBot = wallCheck.position;
        }
    }

    #region Walk
    private void walk()
    {
        bool IsWalking = false;

        if (Input.GetKey(KeyCode.D))
        {
            IsWalking = true;
            Vector3 theScale = tran.localScale;
            theScale.x = 1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(100 * speed * Time.deltaTime, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            IsWalking = true;
            Vector3 theScale = tran.localScale;
            theScale.x = 1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(100 * speed * Time.deltaTime, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            IsWalking = true;
            Vector3 theScale = tran.localScale;
            theScale.x = -1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(-100 * speed * Time.deltaTime, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            IsWalking = true;
            Vector3 theScale = tran.localScale;
            theScale.x = -1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(-100 * speed * Time.deltaTime, 0), ForceMode2D.Force);
        }

        if (IsWalking)
        {
            if (ani.GetInteger("status") == 0)
                ani.SetInteger("status", 1);
        }
        else
        {
            if (ani.GetInteger("status") == 1)
                ani.SetInteger("status", 0);
        }
    }
    #endregion

    #region Jump
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && FloorCheck == true)
        {
            jumpingCheck = true;
            MotionAnimator.SetBool("jumping", jumpingCheck);
            rig.AddForce(new Vector2(0, JumpSpeed), ForceMode2D.Impulse);
            ani.SetTrigger("Jump");
            ani.SetBool("status", false);
            ani.SetBool("Run", false);
            ani.SetBool("Jump", true);
        }
    }
    void JumpToFall()
    {
        fallingSpeed = rig.velocity.y;
        if (fallingSpeed <= 1 && FloorCheck == false)
        {
            jumptofallcheck = true;
            MotionAnimator.SetBool("jumptofall", jumptofallcheck);
            MotionAnimator.SetBool("jumping", jumpingCheck);
        }
    }
    #endregion
    void FallingFunction()
    {
        if (fallingSpeed < 0 && FloorCheck == false && jumptofallcheck == true)
        {
            fallingCheck = true;
            MotionAnimator.SetBool("falling", jumptofallcheck);
            MotionAnimator.SetBool("OnFloor", FloorCheck);
        }
    }

    #region Run
    void Run()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 theScale = tran.localScale;
            theScale.x = 1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(RunSpeed * speed * Time.deltaTime, 0), ForceMode2D.Force);
            ani.SetBool("status", false);
            ani.SetBool("Jump", false);
            ani.SetBool("Run", true);

        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 theScale = tran.localScale;
            theScale.x = 1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(RunSpeed * speed * Time.deltaTime, 0), ForceMode2D.Force);
            ani.SetBool("status", false);
            ani.SetBool("Jump", false);
            ani.SetBool("Run", true);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 theScale = tran.localScale;
            theScale.x = -1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(-RunSpeed * speed * Time.deltaTime, 0), ForceMode2D.Force);
            ani.SetBool("status", false);
            ani.SetBool("Jump", false);
            ani.SetBool("Run", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 theScale = tran.localScale;
            theScale.x = -1;
            tran.localScale = theScale;
            rig.AddForce(new Vector2(-RunSpeed * speed * Time.deltaTime, 0), ForceMode2D.Force);
            ani.SetBool("status", false);
            ani.SetBool("Jump", false);
            ani.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            ani.SetBool("Run", false);
        }
        
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }

    private void CheckLedgeClimb()
    {
        if(ledgeDetected && !canClimbLedge)
        {
            canClimbLedge = true;
            if (isFacingRight) 
            {
                ledgePos1 = new Vector2(Mathf.Floor(ledgePosBot.x + wallCheckDistance) - ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
                ledgePos2 = new Vector2(Mathf.Floor(ledgePosBot.x + wallCheckDistance) - ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset2);
            }
            else
            {
                ledgePos1 = new Vector2(Mathf.Ceil(ledgePosBot.x - wallCheckDistance) + ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
                ledgePos2 = new Vector2(Mathf.Ceil(ledgePosBot.x - wallCheckDistance) + ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset2);
            }

            ani.SetBool("Climb", canClimbLedge);
        }

        if(canClimbLedge)
        {
            transform.position = ledgePos1;
        }
    }

    public void FinishLedgeClimb()
    {
        canClimbLedge = false;
        transform.position = ledgePos2;
        ledgeDetected = false;
    }

    private IEnumerator FlashCollider()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        while(temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }
}







