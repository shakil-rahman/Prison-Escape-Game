using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variable for the lerp speed and player position
    public Transform player;
    public float dur = 0.01f;

    //Moves the game Camera along with the player
    void LateUpdate()
    {
        //Moves the Camera with lerp
        if(transform.position != player.position)
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPos, dur);
        }
    }
}
