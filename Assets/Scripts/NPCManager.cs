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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(sentences);
            if (!damagedPlayer)
            {
                HealthManager.damage(damage);
                damagedPlayer = true;
            }            
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
