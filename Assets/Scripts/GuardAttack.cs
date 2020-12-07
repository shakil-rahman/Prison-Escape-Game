using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttack : MonoBehaviour
{
    // References to game objects
    public GuardController parent;
    // Coroutine for damage
    private IEnumerator coroutine;
    private bool damaging = false;

    // Attack player if alerted and not dead
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (parent.isAlerted && collision.tag == "Player" && !parent.isDead)
        {
            coroutine = guardDamage();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator guardDamage()
    {
        // Prevents damage during cooldown
        if(!damaging)
        {
            damaging = true;
            HealthManager.damage(1);
            yield return new WaitForSeconds(1);
            damaging = false;
        }
    }
}