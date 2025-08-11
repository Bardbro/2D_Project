using System.Collections;
using System.Collections.Generic;
using PlayFab;
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
    lvlToload = PlayerPrefs.GetInt("SavedLevel", 2);
    
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
        SetLevel(2);
    }
   public void ExitGame()
   {
    Application.Quit();
   }

    public void LoginSaveLevel()
   {

    lvlToload = PlayerPrefs.GetInt("SavedLevel", 1);
    
     Debug.Log("Loading saved level: " + lvlToload);
    anim.SetTrigger("Fade");
   }

    public void LoginAndMoveToMainScreen()
    {
        Debug.Log("Attempting to log in...");
        PlayfabManager.Instance.LoginButton(); // Call the LoginButton function

        // Wait for the login result
        StartCoroutine(WaitForLogin());
    }

    private System.Collections.IEnumerator WaitForLogin()
    {
        // Wait until the login message text is updated
        while (PlayfabManager.Instance.messageText.text != "Login successful. Welcome " + PlayFabSettings.staticPlayer.PlayFabId)
        {
            yield return null; // Wait for the next frame
        }

        Debug.Log("Login successful! Moving to main screen.");
        SceneManager.LoadScene("Menu"); // Replace "MainScreen" with your actual main screen scene name
    }
   
}
