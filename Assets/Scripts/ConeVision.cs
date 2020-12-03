using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeVision : MonoBehaviour
{
    public GuardController parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the cone finds the player then they are sent to start
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.respawn();
            //change to alert the guards
        }
        if (collision.tag == "DeadGuard")
        {
            //alert all guards
            Debug.Log("Alert!");
        }
    }
}
