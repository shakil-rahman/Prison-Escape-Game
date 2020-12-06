using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    // Variables for CCTV movement and speed
    private int swap = -1;
    public float start;
    public float end;
    public float rotationSpeed = 0.5f;

    // Update is called once per frame
    private void Update()
    {
        // Sets the boundaries where the camera needs to bounce
        if (transform.rotation.eulerAngles.z <= start)
        {
            swap *= -1;
        }
        if (transform.rotation.eulerAngles.z >= end)
        {
            swap *= -1;
        }
        // Changes the clockwise or anticlockwise motion of the camera
        transform.Rotate(Vector3.forward * swap * rotationSpeed * Time.timeScale);

    }

    // Triggered when something enters the CCTV cone of vision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the cone finds the player then alert all guards
        if (collision.tag == "Player")
        {
            GameObject[] guardsArr = GameObject.FindGameObjectsWithTag("Guard");
            foreach(GameObject guard in guardsArr)
            {
                guard.GetComponent<GuardController>().isAlerted = true;
            }
        }
    }
}