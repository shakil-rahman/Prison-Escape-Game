using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAdjustment : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private float musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            musicVolume = PlayerPrefs.GetFloat("Music");
        }
        else
        {
            musicVolume = 0.1f;
            PlayerPrefs.SetFloat("Music", musicVolume);
        }
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMusic.volume = musicVolume;
    }

    public void updateMusic(float newVolume)
    {
        musicVolume = newVolume;
        PlayerPrefs.SetFloat("Music", musicVolume);
    }
}
