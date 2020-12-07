using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // How long the laser is turned on for
    private float activeLength;
    // How long the laser waits between activations
    public float waitLength;
    // The amount of time the laser has waited
    private float timeGap = 0;
    // Stores if laser is active
    private bool isActive = true;
    // Store references to objects
    public GameObject laser;
    public GameObject laserLight;
    // Coroutine for laser damage
    private IEnumerator coroutine;
    private bool damaging = false;

    void Start()
    {
        // Determine how long the laser is active
        // Done at start for consistency within level
        activeLength = Random.Range(2, 8);
    }

    // Update is called once per frame
    void Update()
    {
        timeGap += Time.fixedDeltaTime;
        // Check if laser has been active long enough
        if(timeGap > activeLength)
        {
            // Check if laser was inactive for long enough
            if(timeGap > (activeLength + waitLength))
            {
                // Re-enable laser
                timeGap = 0;
                isActive = true;
                laser.GetComponent<Renderer>().enabled = true;
                laserLight.SetActive(true);
            }
            else
            {
                // Disable laser
                isActive = false;
                laser.GetComponent<Renderer>().enabled = false;
                laserLight.SetActive(false);
            }
        }
    }
    
    // Detect if touching laser
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isActive)
        {
            coroutine = laserDamage();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator laserDamage()
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