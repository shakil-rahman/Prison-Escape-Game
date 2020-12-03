using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBack : MonoBehaviour
{
    private bool attackable = false;
    public GuardController parent;
    public GameObject cone;

    void Update()
    {
        if (attackable)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                parent.isDead = true;
                parent.gameObject.tag = "DeadGuard";
                parent.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Destroy(cone);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        attackable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attackable = false;
    }
}
