using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    private string loadLevel;
    public int startHealth;

    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Health", startHealth);
        PlayerPrefs.SetString("Level", startLevel);
        SceneManager.LoadScene(startLevel);
    }

    public void LoadLevel()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            loadLevel = PlayerPrefs.GetString("Level");
            SceneManager.LoadScene(loadLevel);
        }
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Controls");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
