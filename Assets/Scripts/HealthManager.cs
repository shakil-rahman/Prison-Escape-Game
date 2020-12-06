using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int playerHealth;
    Text textHealth;
    public GameObject gameOver;
    public Text gameOverScore;
    public PauseMenu pause;

    // Start is called before the first frame update
    void Start()
    {
        textHealth = GetComponent<Text>();
        playerHealth = PlayerPrefs.GetInt("Health");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            PlayerPrefs.DeleteAll();
            pause.Pause();
            gameOver.SetActive(true);
            gameOverScore.text = "Score: " + ScoreManager.score;
        }
        textHealth.text = "" + playerHealth;
    }

    public static void damage(int amount)
    {
        playerHealth -= amount;
        itemSoundManager.soundMan.PlayPunchSound();
    }

    public static void addHealth(int amount)
    {
        playerHealth += amount;
    }
}
