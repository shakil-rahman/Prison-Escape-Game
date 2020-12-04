using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Save();
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("Level", nextLevel);
        PlayerPrefs.SetInt("Score", ScoreManager.score);
        PlayerPrefs.SetInt("Health", HealthManager.playerHealth);
    }
}
