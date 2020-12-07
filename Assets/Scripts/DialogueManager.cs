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
        index = -1;
        onDialogue = false;
    }

    //Starts the dialogue screen displaying the sentences
    public void StartDialogue(string[] sentences)
    {
        currentSentences = sentences;
        onDialogue = true;
        dialogueScreen.SetActive(true);
        time.PauseTimer();
    }

    //Incrementing throught the sentences
    public void Continue()
    {
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        //When you can see the dialogue screen then you can skip using E
        //Timer is paused during the dialogue screen
        if (onDialogue)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Continue();
            }
            if (index >= currentSentences.Length)
            {
                index = -1;
                onDialogue = false;
            }
            else {
                dialogue.text = "" + currentSentences[index];
            }
        }
        else
        {
            //Dialogue is hidden and timer is unpaused
            dialogueScreen.SetActive(false);
            time.ResumeTimer();
        }
    }
}
