using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVel = 12; //move speed
    public float sideVel = 100; //rotate speed
    public float jumpSpeed = 100; //initial jump speed, affects height
	public float numJumps = 1;


    Vector3 movement = Vector3.zero; // 
    CharacterController charController; //gives access to isGrounded, Move (allows movement and jump)

    Quaternion targetRotation; 
    Rigidbody rBody; //treats as solid object that can move. req'd for movement

    float forwardInput, sideInput;
	float jumpCounter = 0;

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
        sideInput = 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        sideInput = Input.GetAxis("Horizontal");
        
    }

    void Update()
    {
        
        //Turn();
    }

    void FixedUpdate()
    {
		GetInput();
        Run();
        Jump();
    }

    void Jump()
    {
		if (Input.GetButtonDown("Jump") && jumpCounter < numJumps){
            //print("Jump");

			movement.y = jumpSpeed;
			jumpCounter++;


        }
		if (Input.GetButtonDown("Fire1") && charController.isGrounded){
			//print("Jump");
			GetComponent<DeathandRespawn>().Death();

		}

		if (!charController.isGrounded) {
			movement.y += Physics.gravity.y * Time.deltaTime; //gravity val is negative
		} else {
			jumpCounter = 0;
		}


        charController.Move(movement * Time.deltaTime);
    }

    void Run()
    {

		double movementScaling = ((charController.isGrounded) ? 1 : 0.5);
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
			movement.x = forwardInput * forwardVel * (float)movementScaling * Time.deltaTime;
        }
		else
        {
            //no movement, but jump is allowed

			movement.x = 0;
        }

		if (Mathf.Abs (sideInput) > inputDelay) {
			movement.z = sideInput * sideVel * (float)movementScaling * Time.deltaTime;
		} else {
			movement.z = 0;
		}


    }

    void Turn()
    {	
	 }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
		if(hit.gameObject.tag.Equals("Trap")){
			GetComponent<DeathandRespawn>().Death();
		}
			
		Rigidbody body = hit.collider.attachedRigidbody;

        if(body == null || body.isKinematic){return;}

        //if (hit.moveDirection.y < -0.3f) { return; }

        Vector3 pushDir = hit.moveDirection;
        body.velocity = pushDir * 2f;
    }


	public void restartJump(){
		movement.y = 0;
	}
}
