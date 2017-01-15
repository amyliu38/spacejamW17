using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public bool levelStart = false;
	PlayerMovement playerscript;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerscript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;
		if (Physics.SphereCast (transform.position, .35f, transform.up, out hit, 5f)) {
			if (hit.transform.CompareTag ("Player")) {
				//playerscript.disableMovement ();
				//Invoke ("playerscript.disableMovement", 0.001f);
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

	public void LowerElevator(){
		anim.SetTrigger ("Lower");
	}


}
