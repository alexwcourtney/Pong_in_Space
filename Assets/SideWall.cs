using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
        //this will detect if there is something colliding with either side wall.
        //if that something is the ball, then we'll call the Score() method to update our score and then reset the ball to the middle.
    {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            gameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("restartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/