using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Variable for movement and animation
    public float moveSpeed = 6.5f;
    public Rigidbody2D rb;
    public Animator anim;
    // Store all the keys collected
    public static List<string> keys;
    // Vectors to store location and movement
    Vector2 movement;
    Vector3 start;

    public AudioSource walkingsound;

    // Stores start position and adds "Cell" door
    private void Awake()
    {
        start = rb.position;
        keys = new List<string>();
        // Allows prisoner to escape the first door
        keys.Add("Cell");
    }

    // Update is called once per frame
    void Update()
    {
        // Retrieves the movement value on x and y axis
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Plays footstep sound if moving
        if(movement.x != 0 || movement.y != 0)
        {
            // Prevents sound from overlapping
            if(!walkingsound.isPlaying)
            {
                walkingsound.Play();
            }
        }
        else
        {
          walkingsound.Stop();
        }

        // Changes the animation based on the movement value
        anim.SetFloat("speedX", movement.x);
        anim.SetFloat("speedY", movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }

    // Moves the player at a constant rate
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Returns player to the start point
    public void respawn()
    {
        rb.position = start;
    }

    // Triggered when player enters another collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks the key, adds it to the list then destroys it
        Key key = collision.GetComponent<Key>();
        if (key != null)
        {
            keys.Add(key.getKeyType());
            Destroy(key.gameObject);
        }
        // Checks if we have the key for the door and opens it if we do
        Door door = collision.GetComponent<Door>();
        if (door != null)
        {
            if (keys.Contains(door.getDoorType()))
            {
                door.OpenDoor();
            }
        }
    }
}
