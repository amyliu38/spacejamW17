using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour {
    AudioSource sound;
	public NextLevel elevator;
	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.transform.CompareTag ("Player")) {
			elevator.LowerElevator();
            AudioSource.PlayClipAtPoint(sound.clip, transform.position);
            Destroy (this.transform.parent.gameObject);
		}
	}
}
