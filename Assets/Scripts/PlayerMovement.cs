﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVel = 12; //move speed
    public float rotateVel = 100; //rotate speed
    public float jumpSpeed = 100; //initial jump speed, affects height

    Vector3 movement = Vector3.zero; // 
    CharacterController charController; //gives access to isGrounded, Move (allows movement and jump)

    Quaternion targetRotation; 
    Rigidbody rBody; //treats as solid object that can move. req'd for movement

    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {

        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The Character needs a Rigidbody");
        }

        if (GetComponent<CharacterController>())
        {
            charController = GetComponent<CharacterController>();
        }
        else
        {
            Debug.LogError("The Character needs a CharacterController");
        }

        forwardInput = 0;
        turnInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        
    }

    void Update()
    {
        GetInput();
        Turn();
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && charController.isGrounded)
        {
            print("Jump");
            movement.y = jumpSpeed;

        }
        if (!charController.isGrounded)
        {
            movement.y += Physics.gravity.y * Time.deltaTime; //gravity val is negative
        }
        charController.Move(movement * Time.deltaTime);
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
            float tempJumpVar = movement.y;
            double movementScaling = ((charController.isGrounded) ? 1 : 0.5);
            movement = transform.forward * forwardInput * forwardVel * (float)movementScaling; //reset vector, including y, which we dont want
            movement.y = tempJumpVar; //resets y to previous intended value
        }
        else
        {
            //no movement, but jump is allowed
            movement.x = 0;
            movement.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if(body == null || body.isKinematic){return;}

        //if (hit.moveDirection.y < -0.3f) { return; }

        Vector3 pushDir = hit.moveDirection;
        body.velocity = pushDir * 2f;
    }
}
