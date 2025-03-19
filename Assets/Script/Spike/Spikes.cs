using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Spikes : MonoBehaviour
{
     

    public float damage;
    public float forceX;
    public float forceY;
    public float duration;

   private void OnTriggerEnter2D(Collider2D collision) {

        PlayerStats playerStats = collision.GetComponent<PlayerStats>();
        if (playerStats != null) {
            playerStats.TakeDamage(damage);
        } else {
            Debug.LogWarning("PlayerStats component not found on the collided object.");
        }

      
        PlayerMoveControl playerMove = collision.GetComponentInParent<PlayerMoveControl>();
        if (playerMove != null) {
            StartCoroutine(playerMove.KnockBack(forceX, forceY, duration, transform));
        } else {
            Debug.LogWarning("PlayerMoveControl component not found in the parent of the collided object.");
        }



    }
    // Start is called before the first frame update
  
}
