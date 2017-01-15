using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3[] pos = new Vector3[]{  new Vector3(-.25f, 4.75f, -2.5f),  
									new Vector3(2.5f, 4.75f, 3f),
									new Vector3(4f, 4.75f, -3.5f),
									new Vector3(1.5f, 4.75f, 3f)};
	Vector3[] rot = new Vector3[]{	new Vector3(45f, 60f, 0f),  
									new Vector3(45f, 200f, 0f),
									new Vector3(45f, -60f, 0f),
									new Vector3(45f, -200f, 0f)};

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("CameraRight") > 0.2f){
			anim.SetTrigger ("right");
		}

		if (Input.GetAxis("CameraLeft") > 0.2f) {
			anim.SetTrigger ("left");
		}
	}
}
