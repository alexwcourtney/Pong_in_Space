using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float yBound = 2.25f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //???
        
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;  //velocity setup
        if (Input.GetKey(moveUp))  //if the move-up key is pressed
        {
            vel.y = speed;  //if up button is pressed, we move up
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed; //otherwise we want it to move down
        }
        else
        {
            vel.y = 0;  //no motion if no key is pressed.
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > yBound)  // if the y-position is beyond the yBound, set y-position to the yBound.  This ensures the paddles don't run off the screen.
        {
            pos.y = yBound;
        }
        else if (pos.y < -yBound)
        {
            pos.y = -yBound;  //  Same boat for the other way around.
        }
        transform.position = pos;
    }
}
