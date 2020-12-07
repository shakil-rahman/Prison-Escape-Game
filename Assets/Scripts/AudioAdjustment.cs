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
        //Checks if there is a Volume preset and set the volume
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

    //Changes the volume of the music
    void Update()
    {
        backgroundMusic.volume = musicVolume;
    }

    //Called when slider is moved
    public void updateMusic(float newVolume)
    {
        musicVolume = newVolume;
        PlayerPrefs.SetFloat("Music", musicVolume);
    }
}
