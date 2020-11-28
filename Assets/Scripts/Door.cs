using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Variable for the value of the door
    public string doorType;
    private Vector3 open;
  
    //Check if we need to continue opening the door
    private bool cont = false;

    //Returns the colour of the door
    public string getDoorType()
    {
        return doorType;
    }

    //Opens the door
    public void OpenDoor()
    {
        open = new Vector3(-2, 0, 0);
    }

    //Only opens the door when E is pressed
    private void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            cont = true;


        }
        if (transform.position != open && cont)
        {
            transform.position = Vector3.Lerp(transform.position, open, 0.01f);
        }
        //Checks when the door is opened
        if (transform.position == open)
        {
            cont = false;

        }
    }
}
