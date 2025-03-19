using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAttack : EnemyAttack
{
    PlayerMoveControl playerMove;
    public float forceX;
    public float forceY;
    public float duration;
    // Start is called before the first frame update
    public override void SpecialAttack()
    {
        playerMove = playerStats.GetComponentInParent<PlayerMoveControl>();
        StartCoroutine(playerMove.KnockBack(forceX,forceY,duration,transform.parent));
    }
}
