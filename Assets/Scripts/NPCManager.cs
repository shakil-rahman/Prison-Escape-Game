using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public string[] sentences;
    private bool inTrigger;

    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(sentences);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            inTrigger = false;
    }
}
