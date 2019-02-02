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

    bool isCrouching = false;
    bool isJumping = false;
    bool jumpedLeft = false;
    bool jumpedRight = false;
    KeyCode jumpPressed = KeyCode.W;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;

    private void Start()
    {
        horizontalDirection = horizontalMove * runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        isJumping = Input.GetKeyDown(jumpPressed);
        jumpedLeft = Input.GetKeyDown(left);
        jumpedRight = Input.GetKeyDown(right);
 
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

        controller.Move(horizontalDirection * Time.fixedDeltaTime, isCrouching, isJumping);
        isJumping = false;
    }

    void FixedUpdate()
    {
        
    }
}
