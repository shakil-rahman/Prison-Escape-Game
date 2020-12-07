using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    public string nextLevel;
    public GameObject levelComplete;
    public Text score;
    public PauseMenu pause;

    //Checks if Player reaches the end of the level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Adds the points and Saves the values
        if(collision.tag == "Player")
        {
            pause.Pause();
            ScoreManager.addPoints(HealthManager.playerHealth * 10);
            ScoreManager.addPoints(TimerController.getTime() * 10);
            levelComplete.SetActive(true);
            score.text = "Score: " + ScoreManager.score;
            Save();
        }
    }

    //Loads in the next level when button pressed
    public void loadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    //Saves the value when entered the trigger
    public void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Level", nextLevel);
        PlayerPrefs.SetInt("Score", ScoreManager.score);
        PlayerPrefs.SetInt("Health", HealthManager.playerHealth);
    }
}
