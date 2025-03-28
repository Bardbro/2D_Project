using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    // Start is called before the first frame update
   private Animator anim;
   public int lvlToload;
   void Start ()
   {
    anim = GetComponent<Animator>();

    GameManager.RegisterFader(this);
   }
   public void LoadSaveLevel()
   {
    lvlToload = PlayerPrefs.GetInt("SavedLevel", 1);
    
     Debug.Log("Loading saved level: " + lvlToload);
    anim.SetTrigger("Fade");
   }

   public void SetLevel(int lvl)
   {
    lvlToload = lvl;
    anim.SetTrigger("Fade");
   }
      public void LoadLevel()
   {
    SceneManager.LoadScene(lvlToload);
   }

   private void Restart()
   {
    SetLevel(SceneManager.GetActiveScene().buildIndex);
    Debug.Log("show index ");
   }
   public void RestartLevel()
   {
    Invoke("Restart",1.5f);
   }

   // New function to reset to level 1 and clear all saved data
    public void ResetToLevelOne()
    {
        // Reset saved level to 1
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        // Reset other statuses (if any)
        Debug.Log("Resetting to level 1 and clearing all statuses.");

        // Set level to 1 and trigger fade animation
        SetLevel(1);
    }
   public void ExitGame()
   {
    Application.Quit();
   }
   
}
