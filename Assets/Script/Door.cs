 using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Door : MonoBehaviour
{
    public Sprite unlockSprite;
    public int lvlToload;
    public Fader fader;
    private BoxCollider2D boxCol;
  
    // Start is called before the first frame update
   
    // private void RestartLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
    // // Update is called once per frame
    // private void LoadLevel()
    // {
    //     SceneManager.LoadScene(lvl);


    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        GameManager.RegisterDoor(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCol.enabled = false;
            collision.GetComponentInChildren<GatherInput>().DisableControls();
            
            PlayerStats playerStats = collision.GetComponentInChildren<PlayerStats>();
            PlayerPrefs.SetFloat("HealthKey", playerStats.health);
            // fader.SetLevel(lvlToload);
            // fader.RestartLevel();
            PlayerCollectable collectibles = collision.GetComponentInChildren<PlayerCollectable>();
            PlayerPrefs.SetInt("GemNumber", collectibles.gemNumber);
            GameManager.ManagerLoadLevel(lvlToload);
        }
    }
    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockSprite;
        boxCol.enabled = true;
    }
}
