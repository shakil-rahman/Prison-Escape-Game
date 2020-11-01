using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    //Variable for CCTV movement and speed
    public bool swap = true;
    public float start;
    public float end;
    public float rotationSpeed = 0.5f;

    //Update is called once per frame
    private void Update()
    {
        //Sets the boundaries where the camera needs to bounce
        if (transform.rotation.eulerAngles.z <= start)
        {
            swap = !swap;
        }
        if (transform.rotation.eulerAngles.z >= end)
        {
            swap = !swap;
        }
        //Changes the clockwise or anticlockwise motion of the camera
        if (swap)
        {
            transform.Rotate(Vector3.forward * -rotationSpeed);
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
    }

    //Triggered when something enters the CCTV cone of vision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the cone finds the player then they are sent to start
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.respawn();
        }
    }
}