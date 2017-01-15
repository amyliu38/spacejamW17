using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continuousAudio : MonoBehaviour {
    AudioSource music;

    // Use this for initialization
	void Awake () {
        music = GetComponent<AudioSource>();
        music.Play();
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(music);
		
	}
}
