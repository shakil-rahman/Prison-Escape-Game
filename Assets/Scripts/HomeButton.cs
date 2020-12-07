using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    //Returns to main menu when pressed
    public void home()
    {
        SceneManager.LoadScene("Main Menu");
    }
}