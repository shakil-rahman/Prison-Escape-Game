using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GuardController : MonoBehaviour
{
    // Reference to pathfinder
    public AIPath path;

    // References to objects
    public Rigidbody2D rb;
    public Animator anim;
    public Transform cone;
    public Transform back;
    // Variables for movement and animation
    public float speedX;
    public float speedY;
    private float oldSpeedX;
    private float oldSpeedY;
    public float moveSpeed = 3f;
    private bool directionChanged;

    // Guard status
    public bool isDead;
    public bool isAlerted;

    // Length of time before guard stops being alert
    public float alertLength;
    private float timeAlerted = 0;
    public float range;

    // Vector to store movement
    private Vector2 movement;

    // Make sure guard is alive and not alerted at level start
    void Start()
    {
        isDead = false;
        isAlerted = false;    
    }

    // Update is called once per frame
    void Update()
    {
        // Set the movement on the x and y axis to the correct variable
        if (isDead)
        {
            speedX = 0f;
            speedY = 0f;
        }
        // Chase player if alerted
        else if (isAlerted)
        {
            cone.gameObject.SetActive(false);
            timeAlerted += Time.fixedDeltaTime;
            Vector2 guardLoc = gameObject.transform.position;
            Vector2 playerLoc = GameObject.FindWithTag("Player").transform.position;
            // If guard is too far and has been alert for long enough, disengage
            if ((timeAlerted > alertLength) && ((playerLoc - guardLoc).sqrMagnitude > range))
            {
                // Reset timer and alert status
                isAlerted = false;
                timeAlerted = 0;
                // Stop guard so they can find the nearest waypoint
                speedX = 0f;
                speedY = 0f;
                // Head towards nearest waypoint from player
                Vector2 way = GetNearest.nearest(playerLoc, "Waypoint").transform.position;
                Vector2 dirToWaypoint = (way - guardLoc).normalized;
                cone.gameObject.SetActive(true);
                changeDirection(dirToWaypoint);
                speedX = dirToWaypoint.x * 1.5f;
                speedY = dirToWaypoint.y * 1.5f;
            }
            else
            {
                // Head towards player
                Vector2 dirToPlayer = path.desiredVelocity.normalized;
                changeDirection(dirToPlayer);
                speedX = dirToPlayer.x * 1.5f;
                speedY = dirToPlayer.y * 1.5f;
            }
        }
        movement.x = speedX;
        movement.y = speedY;

        // Changes the animation based on the movement value
        anim.SetFloat("speedX", speedX);
        anim.SetFloat("speedY", speedY);
        anim.SetFloat("speed", movement.sqrMagnitude);

        rotateCone();

    }

    // Remember previous direction
    public void changeDirection(Vector2 newDir)
    {
        oldSpeedX = speedX;
        oldSpeedY = speedY;
        speedX = newDir.x;
        speedY = newDir.y;
        directionChanged = true;
    }

    // Re-align cone/back
    public void stopMovement()
    {
        Vector2 guardLoc = gameObject.transform.position;
        if (oldSpeedX > 0){
            cone.position = new Vector3(guardLoc.x - 2, guardLoc.y, 0);
            back.position = new Vector3(guardLoc.x - 2, guardLoc.y, 0);
        }
        else if(oldSpeedX < 0){
            cone.position = new Vector3(guardLoc.x + 2, guardLoc.y, 0);
            back.position = new Vector3(guardLoc.x + 2, guardLoc.y, 0);
        }
        else if(oldSpeedY > 0){
            cone.position = new Vector3(guardLoc.x, guardLoc.y - 2, 0);
            back.position = new Vector3(guardLoc.x, guardLoc.y - 2, 0);
        }
        else if(oldSpeedY < 0){
            cone.position = new Vector3(guardLoc.x, guardLoc.y + 2, 0);
            back.position = new Vector3(guardLoc.x, guardLoc.y + 2, 0);
        }
    }

    public Vector2 getMovement()
    {
        return movement;
    }

    // Moves the guard at a constant rate
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Rotate vision cone when guard changes direction
    private void rotateCone()
    {
        Vector2 guardLoc = gameObject.transform.position;
        if (directionChanged)
        {
            stopMovement();

            // Make cone face right if heading right
            if (speedX > 0)
            {
                cone.position = new Vector3(guardLoc.x + 2, guardLoc.y, 0);
                cone.rotation = Quaternion.Euler(Vector3.forward * 0);
                back.position = new Vector3(guardLoc.x + 2, guardLoc.y, 0);
                back.rotation = Quaternion.Euler(Vector3.forward * 0);
            }
            // Make cone face left if heading left
            else if (speedX < 0)
            {
                cone.position = new Vector3(guardLoc.x - 2, guardLoc.y, 0);
                cone.rotation = Quaternion.Euler(Vector3.forward * 180);
                back.position = new Vector3(guardLoc.x - 2, guardLoc.y, 0);
                back.rotation = Quaternion.Euler(Vector3.forward * 180);
            }
            // Make cone face up if heading up
            else if (speedY > 0)
            {
                cone.position = new Vector3(guardLoc.x, guardLoc.y + 2, 0);
                cone.rotation = Quaternion.Euler(Vector3.forward * 90);
                back.position = new Vector3(guardLoc.x, guardLoc.y + 2, 0);
                back.rotation = Quaternion.Euler(Vector3.forward * 90);
            }
            // Make cone face down if heading down
            else if (speedY < 0)
            {
                cone.position = new Vector3(guardLoc.x, guardLoc.y - 2, 0);
                cone.rotation = Quaternion.Euler(Vector3.forward * -90);
                back.position = new Vector3(guardLoc.x, guardLoc.y - 2, 0);
                back.rotation = Quaternion.Euler(Vector3.forward * -90);
            }
            directionChanged = false;
        }
    }
}