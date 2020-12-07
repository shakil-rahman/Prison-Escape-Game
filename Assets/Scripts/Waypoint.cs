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
        // Add possible directions to arraylist
        if (up){directionsAllowed.Add(new Vector2(0f, 1f));}
        if (down){directionsAllowed.Add(new Vector2(0f, -1f));}
        if (left){directionsAllowed.Add(new Vector2(-1f, 0f));}
        if (right){directionsAllowed.Add(new Vector2(1f, 0f));}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Guard")
        {
            GuardController guard = collision.GetComponent<GuardController>();
            if (directionsAllowed.Count == 1){
                guard.changeDirection(directionsAllowed[0]); // Only one option so no need to randomise
                return;
            }
            Vector2 currentDir = guard.getMovement();
            // Duplicate list so it doesn't remove from the main one
            List<Vector2> choices = new List<Vector2>(directionsAllowed);
            // Prevent Guards doing a U-turn at a junction
            choices.Remove(currentDir * -1);
            Vector2 newDir = choices[Random.Range(0, choices.Count)];
            guard.changeDirection(newDir);
        }
    }
}