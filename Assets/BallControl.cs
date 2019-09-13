using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void ballStartMoving()
    {
        float rand = Random.Range(0, 2);  //this will generate a number, 0 or 1
        if (rand < 1)  // if the random is < 1, the ball will start moving right
        {
            rb2d.AddForce(new Vector2(20, -15));  //moves right and down.
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));  //otherwise, start moving left and down.
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  //init rb2d variable
        Invoke("ballStartMoving", 2);  //this will call ballStartMoving after two seconds.
    }
    void resetBall()
    {
        rb2d.velocity = new Vector2 (0,0);  //stops the ball when a goal is scored/win condition is met;
        transform.position = Vector2.zero;  //this updates the velocity value.
    }

    void restartGame() //this will restart the game when the button is pushed, and it'll use our resetBall function and invoke.
    {
        resetBall();

        //if win condition = false:
        Invoke("ballStartMoving", 1);
    }
    //the following function will wait until we collide with a paddle and then updates the velocity using ball speed and paddle speed.
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
