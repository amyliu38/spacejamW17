using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continuousAudio : MonoBehaviour {
    AudioSource audio;

    // Use this for initialization
	void Awake () {
        audio = GetComponent<AudioSource>();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
