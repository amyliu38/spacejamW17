using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		print (coll.transform.tag);
		if (coll.transform.CompareTag ("Player")) {
			//update UI?
			Destroy (gameObject);
		}
	}
}
