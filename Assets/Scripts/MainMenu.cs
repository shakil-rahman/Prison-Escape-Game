using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    private string loadLevel;
    public int startHealth;

    //Starts a fresh game with score and health reset
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Health", startHealth);
        PlayerPrefs.SetString("Level", startLevel);
        SceneManager.LoadScene(startLevel);
    }

    //Loads game with previous score and health
    public void LoadLevel()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            loadLevel = PlayerPrefs.GetString("Level");
            SceneManager.LoadScene(loadLevel);
        }
    }

    //Loads control menu
    public void HowToPlay()
    {
        SceneManager.LoadScene("Controls");
    }

    //Exits the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
