using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAdded;

    //Checks if Player walks over the pickup item
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Increases the health and destroys the item
        if(collision.name == "Player")
        {
            HealthManager.addHealth(healthAdded);
            Destroy(gameObject);
        }
    }
}
