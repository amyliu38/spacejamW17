using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;
    public float jumpSpeed = 100;

    Vector3 movement = Vector3.zero;
    CharacterController charController;

    Quaternion targetRotation;
    Rigidbody rBody;

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
        if (Input.GetButtonDown("Jump") && charController.isGrounded)
        {
            print("Jump");
            movement.y = jumpSpeed;
       
        }
    }

    void Update()
    {
        GetInput();
        Turn();
    }

    void FixedUpdate()
    {
        Run();
        if (!charController.isGrounded)
        {
            movement.y += Physics.gravity.y * Time.deltaTime;
        }
        charController.Move(movement * Time.deltaTime);
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
            float j = movement.y;
            double movementScaling = ((charController.isGrounded) ? 1 : 0.5);
            movement = transform.forward * forwardInput * forwardVel * (float)movementScaling;
            movement.y = j;
        }
        else
        {
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
