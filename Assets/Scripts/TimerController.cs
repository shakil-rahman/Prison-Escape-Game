using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float time;
    Text textTime;

    // Start is called before the first frame update
    void Start()
    {
        textTime = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = 0;
        }
        textTime.text = time.ToString("0");
    }
}
