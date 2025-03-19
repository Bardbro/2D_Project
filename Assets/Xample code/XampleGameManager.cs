// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     public string currentLevel;
//     public bool isGameActive;

//     private void Start()
//     {
//         currentLevel = "MainMenu";
//         isGameActive = false;
//     }

//     public void StartGame()
//     {
//         isGameActive = true;
//         currentLevel = "Game";
//         // Load the game scene
//         UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
//     }

//     public void EndGame()
//     {
//         isGameActive = false;
//         // Handle end game logic, such as showing a game over screen
//     }

//     public void RestartGame()
//     {
//         // Restart the current level
//         UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel);
//     }
// }