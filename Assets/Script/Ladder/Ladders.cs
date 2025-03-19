using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
   private GatherInput gI;
   private PlayerMoveControl pMC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gI = collision.GetComponent<GatherInput>();
        pMC = collision.GetComponent<PlayerMoveControl>();
         Debug.Log("Entered Ladder Trigger");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
    if(gI != null && gI.tryToClimb)
    {
        if(pMC != null)
        {
           pMC.onLadders = true;
           Debug.Log("Staying on Ladder");
        }
    }
}
    private void OnTriggerExit2D(Collider2D collision)
    {
    if(pMC != null)
    {
       pMC.ExitLadder();
      Debug.Log("Exited Ladder Trigger");
    }
}
}
