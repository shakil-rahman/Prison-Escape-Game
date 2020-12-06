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

    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    public void loadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Level", nextLevel);
        PlayerPrefs.SetInt("Score", ScoreManager.score);
        PlayerPrefs.SetInt("Health", HealthManager.playerHealth);
    }
}
