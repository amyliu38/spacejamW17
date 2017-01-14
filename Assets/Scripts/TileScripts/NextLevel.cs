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
		RaycastHit hit;
		if (Physics.SphereCast (transform.position, .35f, transform.up, out hit, 5f)) {
			if (hit.transform.CompareTag ("Player")) {
				anim.SetTrigger ("Rise");
			}
		}
	}

	void LoadNextLevel(){
		if (!levelStart) {
			int levelIdx = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (++levelIdx);
		}

	}


}
