using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	Animator anim;
	CanvasGroup fade;

	void Start(){
		anim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		fade = GetComponent<CanvasGroup> ();
	}

	public void StartGame(){
		anim.SetTrigger ("startGame");
		StartCoroutine ("FadeMenu");
		//SceneManager.LoadScene ("level1");
	}

	IEnumerator FadeMenu(){
		while (fade.alpha > 0f) {
			fade.alpha -= .1f;
			yield return new WaitForSeconds (.1f);
		}
	}

	public void Restart(){
		SceneManager.LoadScene ("Start");
		Debug.Log ("restarting");
	}

	public void Quit(){
		Application.Quit ();
	}
		
}
