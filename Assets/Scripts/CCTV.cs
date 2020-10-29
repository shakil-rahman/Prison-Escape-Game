using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{
    public bool swap = true;
    public float start;
    public float end;
    public float rotationSpeed = 0.5f;

    private void Update()
    {
        if (transform.rotation.eulerAngles.z <= start)
        {
            swap = !swap;
        }
        if (transform.rotation.eulerAngles.z >= end)
        {
            swap = !swap;
        }
        if (swap)
        {
            transform.Rotate(Vector3.forward * -rotationSpeed);
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("You have been caught!");
        }
    }
}
