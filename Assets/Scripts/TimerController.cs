using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float time;
    public static float publicTime;
    Text textTime;
    public bool pausedTimer;

    // Start is called before the first frame update
    void Start()
    {
        pausedTimer = false;
        textTime = GetComponent<Text>();
    }

    //Pauses the Timer when talking to NPCs
    public void PauseTimer()
    {
        pausedTimer = true;
    }

    //Resumes the Timer once finished talking to NPCs
    public void ResumeTimer()
    {
        pausedTimer = false;
    }

    //Updates the Timer on the HUD
    void FixedUpdate()
    {
        //Checks if timer is paused
        if (!pausedTimer)
            time -= Time.deltaTime;
        if(time < 0)
        {
            time = 0;
            HealthManager.damage(1000000000);
        }
        textTime.text = time.ToString("0");
        publicTime = time;
    }

    //Returns the int of the time for the score added at the level exit
    public static int getTime()
    {
        return (int)publicTime;
    }
}
