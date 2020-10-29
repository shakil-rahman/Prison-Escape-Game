using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorType;
    private Vector3 open;
    private Vector2 close;
    private bool cont = false;

    public string getDoorType()
    {
        return doorType;
    }

    public void OpenDoor()
    {
        open = new Vector3(-2, 0, 0);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cont = true;
        }
        if (transform.position != open && cont)
        {
            transform.position = Vector3.Lerp(transform.position, open, 0.1f);
        }
        if (transform.position == open)
        {
            cont = false;
        }
    }
}
