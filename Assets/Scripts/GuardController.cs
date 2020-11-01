using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    //Variables for movement and animation
    public Rigidbody2D rb;
    public Animator anim;
    public Transform cone;
    public float speedX;
    public float speedY;
    public float moveSpeed = 3f;

    //Vector to store movement
    private Vector2 movement;

    //Update is called once per frame
    void Update()
    {
        //Set the movement on the x and y axis to the correct variable
        movement.x = speedX;
        movement.y = speedY;

        //Changes the animation based on the movement value
        anim.SetFloat("speedX", speedX);
        anim.SetFloat("speedY", speedY);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }

    //Moves the guard at a constant rate
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    //Triggered when player enters another collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This controls the bounce effect where the guard turns 180 degrees
        if (collision.tag == "Wall")
        {
            //Moves the cone of vision and the guard based on the direction they are already moving
            if (speedX < 0)
            {
                cone.position = new Vector3(cone.position.x + 4, cone.position.y, cone.position.z);
                cone.rotation = Quaternion.Euler(Vector3.forward * 0);
            }
            else if (speedX > 0)
            {
                cone.position = new Vector3(cone.position.x - 4, cone.position.y, cone.position.z);
                cone.rotation = Quaternion.Euler(Vector3.forward * 180);
            }
            else if (speedY < 0)
            {
                cone.position = new Vector3(cone.position.x, cone.position.y + 4, cone.position.z);
                cone.rotation = new Quaternion(cone.rotation.x, cone.rotation.y, -cone.rotation.z, cone.rotation.w);
            }
            else if (speedY > 0)
            {
                cone.position = new Vector3(cone.position.x, cone.position.y - 4, cone.position.z);
                cone.rotation = new Quaternion(cone.rotation.x, cone.rotation.y, -cone.rotation.z, cone.rotation.w);
            }
            //Changes the speed to move in the opposite direction
            speedX = -speedX;
            speedY = -speedY;
        }
        //If the cone finds the player then they are sent to start
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.respawn();
        }
    }
}
