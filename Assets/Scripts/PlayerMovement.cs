
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
	float Dest_Angle;
	int rotDirection = 1;
	bool canMove = true; 


	Transform Player_Body;

	Transform axisGuide;

	public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {
		//axisGuide = GameObject.FindGameObjectWithTag ("AxisGuide").transform;

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

    void Update(){
        Turn();
    }

    void FixedUpdate()
	{	
		Jump();
		if (!canMove) {
			movement.x = 0;
			movement.z = 0;
			return;
		}

		GetInput();
        Run();

    }

    void Jump()
    {
		if (Input.GetButton("Jump") && jumpCounter < numJumps && canMove){
            //print("Jump");

			movement.y = jumpSpeed;
			jumpCounter++;


        }
		if (Input.GetButton("Fire1") && charController.isGrounded){
			//print("Jump");
			GetComponent<DeathandRespawn>().Death(false);

		}
		if (Input.GetButtonDown("Restart")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		} 

		if (!charController.isGrounded) {
			movement.y += Physics.gravity.y * Time.deltaTime; //gravity val is negative
		} else {
			jumpCounter = 0;
		}


        charController.Move(movement * Time.deltaTime);
    }

    void Run(){

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

		if (movement.x != 0 || movement.z != 0) {
			
			if (movement.x > 0) {
				//print ("front");
				Dest_Angle = 0;
			}
			else if (movement.x < 0) {
				//print ("back");
				Dest_Angle = 180;
			}

			if (movement.z > 0) {
				//print ("left");
				Dest_Angle = 270;
			}
			else if (movement.z < 0) {
				//print ("right");
				Dest_Angle = 90;
			}
			float YAngle = this.transform.rotation.eulerAngles.y;

			if (Dest_Angle < YAngle) {
				rotDirection = -1;
			} else {
				rotDirection = 1;
			}	

		}

    }

    void Turn(){
		float YAngle = this.transform.rotation.eulerAngles.y;
		//print (YAngle);
		float rotSpeed = 400;



		if(Mathf.Abs(Dest_Angle - YAngle) > 8){
			transform.Rotate (0, rotSpeed * Time.deltaTime * rotDirection, 0);		
		}
				
	}


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
		if(hit.gameObject.tag.Equals("Trap")){
			GetComponent<DeathandRespawn>().Death(true);
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
	public void disableMovement(){
		canMove = false;
	}

	public void reduceSpeed(){
		forwardVel *= .5f;
		sideVel *= .5f;
	}

	public void restoreSpeed(){
		forwardVel*=2f;
		sideVel *= 2f;
	}

	public float getDestAngle(){
		return Dest_Angle;
	}
}
