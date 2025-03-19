using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject gameParticle;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.RegisterGem(this);
    }

 
  private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("Player"))
       {
        collision.GetComponent<PlayerCollectable>().GemCollected();

        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        Instantiate(gameParticle, transform.position, transform.rotation);
        // Destroy(gameObject);
        GameManager.RemoveGemFromList(this);
       }
   }
   private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("GemNumber");
    }
}
