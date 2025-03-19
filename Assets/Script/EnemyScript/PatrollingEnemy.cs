using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PatrollingEnemy : Enemy 
{
    public float speed;
    
    private int direction = -1;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerTocheck;

    private bool dectectGround; 
    private bool detectwall;
    public float radius;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        Flip();
    
        rb.velocity = new Vector2(direction*speed, rb.velocity.y);
   }

    public override void HurtSequence()
    {
        anim.SetTrigger("Hurt");
    }
    public override void DeathSequence()
    {
        anim.SetTrigger("Death");
        speed = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponentInChildren<PolygonCollider2D> ().enabled = false;
        rb.gravityScale = 0;
    }
   private void Flip()
   {
    dectectGround = Physics2D.OverlapCircle(groundCheck.position,radius, layerTocheck);
    detectwall = Physics2D.OverlapCircle(wallCheck.position, radius , layerTocheck);

    if (detectwall || dectectGround == false )
    {
        direction *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, 7 , 1);

    }
   }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position,radius);
        Gizmos.DrawWireSphere(wallCheck.position,radius);
    }
}

