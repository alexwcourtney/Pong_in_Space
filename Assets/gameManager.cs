using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    //create two integers in order to keep each player's score
    public static int p1Score = 0;
    public static int p2Score = 0;
    //next is a GUI for displaying our buttons and graphics (like scorekeeping)
    //the GUI skin object will be made in Unity after this.
    public GUISkin layout;
    //this is just our ball object
    GameObject theball;
    // Start is called before the first frame update
    void Start()
    {
        theball = GameObject.FindGameObjectWithTag("Ball");  //this will happen when the game first starts.
    }
        //need a scoring function
    public static void Score (string wallID)
        {
        //if the game detects the ball hitting the right wall, then that means p1 scored a goal, so p1's score increases by 1.
        if (wallID == "eastWall")
        {
            p1Score = p1Score + 1;
        }
       //otherwise if it hits the left wall, p2 scored, and p2's score increases by 1.
        else
        {
            p2Score = p2Score + 1;
        }
    }
        //This is for score display, and for displaying our reset button.
        //it checks for win conditions every time something happens
        //it'll trigger resetBall() if someone has indeed won.
        void OnGUI()
        {
            GUI.skin = layout;
            GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + p1Score);
            GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + p2Score);
            if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "Restart"))
            {
                p1Score = 0;
                p2Score = 0;
                theball.SendMessage("restartGame", 0.5f, SendMessageOptions.RequireReceiver);  // SendMessage will trigger any function name bearing the same name as the input string, in this case it's RestartGame.
            }
            if (p1Score == 5)
            {
                GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "First Player Wins.");
                theball.SendMessage("resetBall", null, SendMessageOptions.RequireReceiver);  // SendMessage will tell the program to access 'BallControl' Class and trigger the ResetBall() method.
            }
            else if (p2Score == 5)
            {
                GUI.Label(new Rect(Screen.width / 2 + 75, 200, 2000, 1000), "Second player Wins.");
                theball.SendMessage("resetBall", null, SendMessageOptions.RequireReceiver);
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

