using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<Text>();
        score = PlayerPrefs.GetInt("Score");
    }

    //Displays the score on the HUD
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        textScore.text = "" + score;
    }

    //Adds points to the score
    public static void addPoints(int points)
    {
        score += points;
    }
}
