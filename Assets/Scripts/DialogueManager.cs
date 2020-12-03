using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogue;
    public GameObject dialogueScreen;
    private int index;
    private bool onDialogue;
    private string[] currentSentences;
    public TimerController time;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        onDialogue = false;
    }

    public void StartDialogue(string[] sentences)
    {
        currentSentences = sentences;
        onDialogue = true;
        dialogueScreen.SetActive(true);
        time.PauseTimer();
    }

    public void Continue()
    {
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        if (onDialogue)
        {
            if (index >= currentSentences.Length)
            {
                index = 0;
                onDialogue = false; 
            }
            else {
                dialogue.text = "" + currentSentences[index];
            }
        }
        else
        {
            dialogueScreen.SetActive(false);
            time.ResumeTimer();
        }
    }
}
