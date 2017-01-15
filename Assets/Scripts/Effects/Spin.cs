using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	public float angularSpeed = 0;
	public Vector3 rotDirection = new Vector3 (0, 1, 0);
	public long switchDelay = 100;
	long counter = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//counter++;
		///if (counter > switchDelay) {
		//	randomizeDirection ();
		//	counter = 0;
		//}

		this.transform.Rotate (rotDirection * angularSpeed * Time.deltaTime);	
	}

	void randomizeDirection(){
		do {
			rotDirection.x = Random.Range (1, 2000) % 2 *  ((Random.Range (1, 2000) % 2 == 0)? 1: -1);
			//rotDirection.y = Random.Range (1, 2000) % 2 *  ((Random.Range (1, 2000) % 2 == 0)? 1: -1);
			rotDirection.z = Random.Range (1, 2000) % 2 *  ((Random.Range (1, 2000) % 2 == 0)? 1: -1);
		} while(rotDirection == Vector3.zero);
	
	}


}
