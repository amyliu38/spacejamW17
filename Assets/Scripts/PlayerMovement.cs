using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVel = 12; //move speed
    public float rotateVel = 100; //rotate speed
    public float jumpSpeed = 100; //initial jump speed, affects height

    Vector3 movement = Vector3.zero; // 
    CharacterController charController; //gives access to isGrounded, Move (allows movement and jump

    Quaternion targetRotation; 
    Rigidbody rBody; //treats as solid object that can move. req'd for movement

    float forwardInput, turnInput;
	float Dest_Angle = 0;
	Transform Player_Body;

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

		Player_Body = GetComponentInChildren<Transform> ();


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
        Jump();
    }

    void Jump()
    {
        if (!charController.isGrounded)
        {
            movement.y += Physics.gravity.y * Time.deltaTime; //gravity val is negative
        }
        charController.Move(movement * Time.deltaTime);
    }

    void Run()
    {

		double movementScaling = ((charController.isGrounded) ? 1 : 0.5);
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
			movement.z = forwardInput * forwardVel * (float)movementScaling;
        }
		else
        {
            //no movement, but jump is allowed

			movement.z = 0;
        }

		if (Mathf.Abs (turnInput) > inputDelay) {
			movement.x = turnInput * rotateVel * (float)movementScaling;
		} else {
			movement.x = 0;
		}

		if (movement.x != 0 || movement.z != 0) {
			Dest_Angle = Mathf.Rad2Deg * Mathf.Atan2 (movement.z, movement.x);
		}

		//print(Dest_Angle);

    }

    void Turn()
    {	
		int Dir = (Dest_Angle < (Player_Body.rotation.eulerAngles.y-90)) ? -1 : 1;
		if (Mathf.Abs(Dest_Angle - (Player_Body.rotation.eulerAngles.y-90)) > 30){
			
			Player_Body.Rotate (0, Dir * 70 * Time.deltaTime, 0);
        }
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
