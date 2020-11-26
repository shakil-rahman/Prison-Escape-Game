using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    // Variables for movement and animation
    public Rigidbody2D rb;
    public Animator anim;
    public Transform cone;
    public float speedX;
    public float speedY;
    private float oldSpeedX;
    private float oldSpeedY;
    public float moveSpeed = 3f;
    private bool directionChanged;

    // Vector to store movement
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Set the movement on the x and y axis to the correct variable
        movement.x = speedX;
        movement.y = speedY;

        // Changes the animation based on the movement value
        anim.SetFloat("speedX", speedX);
        anim.SetFloat("speedY", speedY);
        anim.SetFloat("speed", movement.sqrMagnitude);

        // Rotate vision cone when guard changes direction
        if (directionChanged)
        {
            stopMovement();

            if (speedX > 0){
                cone.position = new Vector3(cone.position.x + 2, cone.position.y, cone.position.z);
                cone.rotation = Quaternion.Euler(Vector3.forward * 0);
            }
            else if (speedX < 0){
                cone.position = new Vector3(cone.position.x - 2, cone.position.y, cone.position.z);
                cone.rotation = Quaternion.Euler(Vector3.forward * 180);
            }
            else if (speedY > 0){
                cone.position = new Vector3(cone.position.x, cone.position.y + 2, cone.position.z);
                cone.rotation = Quaternion.Euler(Vector3.forward * 90);
            }
            else if (speedY < 0){
                cone.position = new Vector3(cone.position.x, cone.position.y - 2, cone.position.z);
                cone.rotation = Quaternion.Euler(Vector3.forward * -90);
            }
            directionChanged = false;
        }
    }

    public void changeDirection(Vector2 newDir)
    {
        oldSpeedX = speedX;
        oldSpeedY = speedY;
        speedX = newDir.x;
        speedY = newDir.y;
        directionChanged = true;
    }

    public void stopMovement()
    {
        if (oldSpeedX > 0){
            cone.position = new Vector3(cone.position.x - 2, cone.position.y, cone.position.z);
        }
        else if(oldSpeedX < 0){
            cone.position = new Vector3(cone.position.x + 2, cone.position.y, cone.position.z);
        }
        else if(oldSpeedY > 0){
            cone.position = new Vector3(cone.position.x, cone.position.y - 2, cone.position.z);
        }
        else if(oldSpeedY < 0){
            cone.position = new Vector3(cone.position.x, cone.position.y + 2, cone.position.z);
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

    // Triggered when guard enters another collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the cone finds the player then they are sent to start
        if (collision.tag == "Player"){
            PlayerController player = collision.GetComponent<PlayerController>();
            player.respawn();
        }
    }
}