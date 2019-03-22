using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 70f;
    
    float horizontalMove = 1f;
    float verticalMove = 0f;
    float horizontalDirection = 1f;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    bool isCrouching = false;
    bool isJumping = false;
    bool jumpedLeft = false;
    bool jumpedRight = false;
    KeyCode jumpPressed = KeyCode.W;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;

    Touch playerTouch;

    private void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        // horizontalDirection = horizontalMove * runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        isJumping = Input.GetKeyDown(jumpPressed);
        jumpedLeft = Input.GetKeyDown(left);
        jumpedRight = Input.GetKeyDown(right);

        playerTouch = Input.GetTouch(1);
 
        if (horizontalMove != 0)
        {
            horizontalDirection = horizontalMove;
        }

        if (verticalMove < 0)
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        
        isJumping = false;

    */

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            controller.Move(runSpeed * Time.fixedDeltaTime, isCrouching, isJumping);
                        }
                        else
                        {   //Left swipe
                            controller.Move(-(runSpeed * Time.fixedDeltaTime), isCrouching, isJumping);
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            controller.Move(0 * Time.fixedDeltaTime, isCrouching, true);
                        }
                        else
                        {   //Down swipe
                            controller.Move(0 * Time.fixedDeltaTime, true, isJumping);
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }

    void FixedUpdate()
    {
        
    }
}