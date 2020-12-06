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
        if (attackable)
        {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            attackable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attackable = false;
    }
}
