using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
        PlayerStats playerstats = collision.GetComponentInChildren<PlayerStats>();
        if (playerstats.health == playerstats.maxHealth){
            return;
        }
        playerstats.IncreaseHealth(heal);
        Destroy(gameObject);
        }
    }
   
}
