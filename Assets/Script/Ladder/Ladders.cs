using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
   private GatherInput gI;
   private PlayerMoveControl pMC;

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        gI = collision.GetComponent<GatherInput>();
        pMC = collision.GetComponent<PlayerMoveControl>();
        
         if (collision.tag == "Player" && gI.tryToClimb)
         {
            pMC.onLadders = true;
         }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
          pMC = collision.GetComponent<PlayerMoveControl>();
    if (collision.tag == "Player")
    {
        pMC.ExitLadder();
        Debug.Log("Exited Ladder Trigger");
    }
}
}
