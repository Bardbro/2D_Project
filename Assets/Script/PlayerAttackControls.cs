using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    private PlayerMoveControl pMC;
    private GatherInput gI;
    private Animator anim;

    public bool attackStarted = false;
    public PolygonCollider2D polyCol;
    public AudioSource source;
    void Start()
    {
        pMC = GetComponent<PlayerMoveControl>();
        gI = GetComponent<GatherInput>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (gI.tryAttack){
            if(attackStarted || pMC.hasControl == false|| pMC.knockback == true || pMC.onLadders){ return; }
            anim.SetBool("Attack", true);
            attackStarted = true;
        }
    }
public void AtivateAttack()
{
    polyCol.enabled = true;
    source.Play();
}
    public void ResetAttack()
    {
        anim.SetBool("Attack", false);
        gI.tryAttack = false;
        attackStarted = false;
        polyCol.enabled=false;
        source.Stop();
    }
     
}
