using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeVision : MonoBehaviour
{
    public GuardController parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the cone finds the player then alert that guard
        if (collision.tag == "Player")
        {
            parent.isAlerted = true;
        }
        // If a dead guard is found alert the guards
        if (collision.tag == "DeadGuard")
        {
            // Alert all guards
            GameObject[] guardsArr = GameObject.FindGameObjectsWithTag("Guard");
            foreach(GameObject guard in guardsArr)
            {
                guard.GetComponent<GuardController>().isAlerted = true;
            }
        }
    }
}
