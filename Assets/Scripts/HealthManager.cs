using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int startHealth;
    public static int playerHealth;
    Text textHealth;

    // Start is called before the first frame update
    void Start()
    {
        textHealth = GetComponent<Text>();
        playerHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
        textHealth.text = "" + playerHealth;
    }

    public static void damage(int amount)
    {
        playerHealth -= amount;
    }

    public static void addHealth(int amount)
    {
        playerHealth += amount;
    }
}
