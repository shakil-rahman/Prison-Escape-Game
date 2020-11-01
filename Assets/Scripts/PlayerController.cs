using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 6.5f;
    public Rigidbody2D rb;
    public Animator anim;
    public Text winText;

    public static List<string> keys;

    Vector2 movement;
    Vector3 start;

    private void Awake()
    {
        start = rb.position;
        keys = new List<string>();
        keys.Add("Cell");
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("speedX", movement.x);
        anim.SetFloat("speedY", movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void respawn()
    {
        rb.position = start;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Key key = collision.GetComponent<Key>();
        if (key != null)
        {
            keys.Add(key.getKeyType());
            Destroy(key.gameObject);
        }
        Door door = collision.GetComponent<Door>();
        if (door != null)
        {
            if (keys.Contains(door.getDoorType()))
            {
                door.OpenDoor();
            }
        }
        if(collision.gameObject.tag == "Win")
        {
            collision.gameObject.SetActive(false);
            winText.text = "You win!";
        }
    }
}
