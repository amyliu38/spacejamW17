using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public bool levelStart = false;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Physics.Raycast (transform.position, transform.up, 5f)) {
			anim.SetTrigger ("Rise");
		}
	}

	void LoadNextLevel(){
		if (!levelStart) {
			int levelIdx = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (++levelIdx);
		}

	}


}
