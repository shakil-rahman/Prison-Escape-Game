using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float dur = 0.1f;

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != player.position)
        {
            Vector3 playerPos = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPos, dur);
        }
    }
}
