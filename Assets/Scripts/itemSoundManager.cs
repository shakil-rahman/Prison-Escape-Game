using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSoundManager : MonoBehaviour
{
    public static itemSoundManager soundMan;
    private AudioSource  audioSrc;
    private AudioClip[] pingsound;
    // Start is called before the first frame update
    void Start()
    {
        soundMan = this;
        audioSrc = GetComponent<AudioSource>();
        pingsound = Resources.LoadAll<AudioClip>("PingSound");
    }

    public void PlayKeyCollectSound()
    {
        audioSrc.PlayOneShot(pingsound[0]);
    }
}
