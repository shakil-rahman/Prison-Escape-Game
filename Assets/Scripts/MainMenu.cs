using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame() {
      Debug.Log("You're trying to play the game");
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        Debug.Log("You're trying to quit the game");
        Application.Quit();
    }
}
