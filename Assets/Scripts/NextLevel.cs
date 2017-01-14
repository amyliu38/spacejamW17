using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll){
		//send message to pause player movement
		coll.transform.parent = transform;
		anim.SetTrigger ("Rise");
	}

	void LoadNextLevel(){
		int levelIdx = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (++levelIdx);
	}


}
