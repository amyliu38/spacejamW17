using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (transform.position, transform.up, 5f)) {
			//trigger some function, door or drawbridge etc
		}
	}
}
