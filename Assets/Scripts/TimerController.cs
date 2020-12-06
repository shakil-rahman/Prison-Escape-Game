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

    public void PauseTimer()
    {
        pausedTimer = true;
    }

    public void ResumeTimer()
    {
        pausedTimer = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

    public static int getTime()
    {
        return (int)publicTime;
    }
}
