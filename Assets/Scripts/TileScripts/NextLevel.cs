using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    AudioSource sound;
	public bool levelStart = false;
	bool started = false;
	PlayerMovement playerscript;
	Animator anim;
	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
		anim = GetComponent<Animator> ();
		playerscript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit hit;
		if (!started && Physics.SphereCast (transform.position, .35f, transform.up, out hit, 5f)) {
			if (hit.transform.CompareTag ("Player")) {
				playerscript.reduceSpeed ();
				playerscript.gameObject.transform.parent = transform;
				//playerscript.disableMovement ();
				//Invoke ("playerscript.disableMovement", 0.001f);
				anim.SetTrigger ("Rise");
				started = true;
			}
		}
	}

	void LoadNextLevel(){
		if (levelStart) {
			playerscript.restoreSpeed ();
			playerscript.gameObject.transform.parent = null;
		} else {
			int levelIdx = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (++levelIdx);
		}

	}

	public void LowerElevator(){
		anim.SetTrigger ("Lower");
	}

    public void PlayAudio()
    {
        sound.Play();
    }
}
