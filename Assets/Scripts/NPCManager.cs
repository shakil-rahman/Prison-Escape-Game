using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public string[] sentences;
    private bool inTrigger;
    public int damage;
    private bool damagedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        damagedPlayer = false;
        inTrigger = false;
    }

    //Starts Dialogue is Player can talk to the NPC
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(sentences);
            //Some NPCs can damage the Player
            if (!damagedPlayer)
            {
                HealthManager.damage(damage);
                damagedPlayer = true;
            }            
        }
    }

    //Checks if Player can talk to the NPC
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            inTrigger = true;
    }

    //Checks if Player cannot talk to the NPC
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            inTrigger = false;
    }
}
