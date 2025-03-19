using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Color = UnityEngine.Color;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class PlayerMoveControl : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private int direction = 1;
    private GatherInput gi;
    private Rigidbody2D rb;
    private Animator anim;
    public int additionalJumps = 2;
    private int jumpResetNumber;

    public float RayLegnth;
    public LayerMask groundlayer;
    public Transform LeftPoint;
     public Transform RightPoint;
    private bool grounded = true;
    private bool doubleJump = true;
    public bool knockback =false ;
    public bool hasControl = true;
    
    public bool onLadders;
    public float climbSpeed;
    public float climbHorizontalSpeed;

    private float startGravity;
    // Start is called before the first frame update
    void Start()
    {
        gi = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startGravity = rb.gravityScale;
        jumpResetNumber = additionalJumps;
    }
    void Update(){
        SetAnimationValue();
    }
    // Update is called once per frame
    private void FixedUpdate() {
        CheckStatus();
        if (knockback || hasControl == false)
        return;
     Move();
     JumpPlayer();
     
   }
    void  CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(LeftPoint.position,Vector2.down,RayLegnth,groundlayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(RightPoint.position,Vector2.down,RayLegnth,groundlayer);
        if (leftCheckHit || rightCheckHit)
        {
            grounded = true;
            additionalJumps = jumpResetNumber;
        }
        else
        {
            grounded = false;
        }
        SeeRay(leftCheckHit);
    }
    private void SeeRay (RaycastHit2D leftCheckHit)
    {
        Color color1 = leftCheckHit ? Color.yellow : Color.red;
        Debug.DrawRay(LeftPoint.position, Vector2.down * RayLegnth, color1);
         Color color2 = leftCheckHit ? Color.yellow : Color.red;
        Debug.DrawRay(RightPoint.position, Vector2.down * RayLegnth, color2);
    }
   private void Move()
   {
    Flip();
     rb.velocity = new Vector2(speed * gi.valueX, rb.velocity.y);
     if (onLadders)
     {
        rb.gravityScale = 0;
        rb.velocity = new Vector2(climbHorizontalSpeed * gi.valueX, climbSpeed * gi.valueY);
        if (rb.velocity.y == 0)
            anim.enabled = false;
            else 
            anim.enabled = true;
     }
   }
   public void ExitLadder()
   {
    rb.gravityScale = startGravity;
    onLadders = false;
    anim.enabled = true;
   }
   private void Flip()
   {
    if(gi.valueX * direction < 0)
    {
        transform.localScale = new Vector3(-transform.localScale.x,1,1);
        direction *= -1;
    }
   }
   private void SetAnimationValue()
   {
      anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
      anim.SetFloat("VSpeed", rb.velocity.y);
      anim.SetBool ("GroundCheck", grounded);
      anim.SetBool("Climb", onLadders);
   }
   private void JumpPlayer()
   {
    if (gi.Jumpvaluable)
    {
        if(grounded)
        {
            ExitLadder();
            rb.velocity = new Vector2(gi.valueX*speed,JumpForce);
            doubleJump = true;
        }
        //  else if (doubleJump)
        //  {
        //      ExitLadder();
        //      rb.velocity = new Vector2(gi.valueX*speed,JumpForce);
        //      doubleJump = false;
        //  }
         else if (additionalJumps>0 )
         {
            ExitLadder();
             rb.velocity = new Vector2(gi.valueX*speed,JumpForce);
             additionalJumps -=1;
         }
        
    }
   
    gi.Jumpvaluable = false;
   }
   public IEnumerator KnockBack(float forceX, float forceY, float duration, Transform otherObject)
   {
    int knockBackDirection;
    if (transform.position.x < otherObject.position.x)
     knockBackDirection = - 1;
     else 
     knockBackDirection = 1;

     knockback = true;
        rb.velocity = Vector2.zero;
        Vector2 theForce = new Vector2(knockBackDirection * forceX, forceY);
        rb.AddForce(theForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        knockback = false;
        rb.velocity = Vector2.zero;
   }
    
}
