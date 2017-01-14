using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float rotateVel = 100;

	Quaternion targetRotation;
	Rigidbody rBody;
	CharacterController charController;

	float forwardInput, turnInput;

	public  Quaternion TargetRotation{
		get{return targetRotation;}
	}

	void Start(){
		targetRotation = transform.rotation;
		if(GetComponent<Rigidbody>()){
			rBody = GetComponent<Rigidbody>();
		}
		else{
			Debug.LogError("The Character needs a Rigidbody");
		}

		if(GetComponent<Rigidbody>()){
			rBody = GetComponent<Rigidbody>();
		}
		else{
			Debug.LogError("The Character needs a Rigidbody");
		}

		forwardInput = 0;
		turnInput = 0;
	}	

	void GetInput(){
		forwardInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
		if (Input.GetButton ("Jump")) {
			print ("Jump");
			rBody.velocity = new Vector3(rBody.velocity.x, 200, rBody.velocity.z);
		}
	}

	void Update(){
		GetInput();
		Turn();
	}

	void FixedUpdate(){
		Run();
	}
		
	void Run(){
		if(Mathf.Abs(forwardInput) > inputDelay){
			//move
			rBody.velocity = transform.forward * forwardInput * forwardVel;
		}
		else{
			//zero velocity
			rBody.velocity = Vector3.zero;
		}
	}

	void Turn(){
		if (Mathf.Abs (turnInput) > inputDelay) {
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}
}
