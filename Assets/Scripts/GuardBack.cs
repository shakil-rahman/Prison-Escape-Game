using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBack : MonoBehaviour
{
    private bool attackable = false;
    public GuardController parent;
    public GameObject cone;
    public GameObject deathParticle;
    public int points;

    void Update()
    {
        //Adds the death particle when the Player attacks the Guard and adds Points
        if (attackable)
        {
            //Checks if the attack key has been pressed
            if (Input.GetKeyDown(KeyCode.R) && !parent.isDead)
            {
                parent.isDead = true;
                parent.gameObject.tag = "DeadGuard";
                parent.gameObject.layer = 0;
                Instantiate(deathParticle, parent.transform.position, parent.transform.rotation);
                parent.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                ScoreManager.addPoints(points);
                Destroy(cone);
            }
        }
    }

    //Makes it so the Player can attack the Guard
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            attackable = true;
    }

    //Makes it so the Player can no longer attack the Guard
    private void OnTriggerExit2D(Collider2D collision)
    {
        attackable = false;
    }
}
