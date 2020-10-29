using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Transform cone;
    public float speedX;
    public float speedY;
    public float moveSpeed = 3f;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = speedX;
        movement.y = speedY;

        anim.SetFloat("speedX", speedX);
        anim.SetFloat("speedY", speedY);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Wall")
        {
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

            speedX = -speedX;
            speedY = -speedY;
        }

        if (collision.tag == "Player")
        {
            Debug.Log("Guard Caught You!!!");
        }
    }
}
