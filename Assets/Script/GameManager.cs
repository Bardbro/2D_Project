using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    private Fader fader;
    private Door theDoor;
    private List<Gem> gems;

   

   private void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

        gems = new List<Gem>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            Destroy(gameObject);
        }
    }
   public static void RegisterDoor(Door door)
   {
    if (GM == null) {
        return;
    }
     GM.theDoor = door;

     
   }
   public static void RegisterFader(Fader fD)
   {
        if (GM == null) {
            return;
        }
        GM.fader = fD;
   }
   public static void ManagerLoadLevel(int index)
   {
    if (GM == null) {
        return ;
    }
    GM.fader.SetLevel(index);
   }
   public static void ManagerRestartLevel()
   {
    if (GM == null) {
        return;
    }
        GM.fader.RestartLevel();
        GM.gems.Clear();
   }

    public static void RegisterGem(Gem gem)
   {
    if (GM == null) {
        return;
     }
   if (!GM.gems.Contains(gem)) {
    GM.gems.Add(gem);
     }
   }
    public static void RemoveGemFromList(Gem gem)
    {
        if (GM == null) {
            return;
     }
    GM.gems.Remove(gem);
    if (GM.gems.Count == 0) {
        GM.theDoor.UnlockDoor();
     }
    }

}
