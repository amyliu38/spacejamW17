using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	Animator anim;
	void Start(){
		anim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
	}

	public void StartGame(){
		anim.SetTrigger ("startGame");
		//SceneManager.LoadScene ("level1");
	}

	public void Restart(){
		SceneManager.LoadScene ("Start");
	}

	public void Quit(){
		Application.Quit ();
	}
		
}
