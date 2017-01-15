using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour {

	public NextLevel elevator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.transform.CompareTag ("Player")) {
			elevator.LowerElevator();
			Destroy (this.transform.parent.gameObject);
		}
	}
}
