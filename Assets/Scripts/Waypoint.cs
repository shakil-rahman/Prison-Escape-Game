using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    private List<Vector2> directionsAllowed;

    // Start is called before the first frame update
    void Start()
    {
        directionsAllowed = new List<Vector2>();

        if (up)
            directionsAllowed.Add(new Vector2(0f, 1f));
        if (down)
            directionsAllowed.Add(new Vector2(0f, -1f));
        if (left)
            directionsAllowed.Add(new Vector2(-1f, 0f));
        if (right)
            directionsAllowed.Add(new Vector2(1f, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Guard")
        {
            GuardController guard = collision.GetComponent<GuardController>();
            Vector2 currentDir = guard.getMovement();
            Vector2 newDir = directionsAllowed[Random.Range(0, directionsAllowed.Count)];
            guard.changeDirection(newDir);
        }
    }
}
