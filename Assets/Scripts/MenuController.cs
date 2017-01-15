using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	Animator anim;
	void Start(){
		anim = FindObjectOfType<Animator>().GetComponent<Animator> ();	
	}

	public void StartGame(){
		anim.SetTrigger ("startGame");
		//SceneManager.LoadScene ("level1");
	}

	public void Quit(){
		Application.Quit ();
	}
		
}
