using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour {

	CanvasGroup panel;
	static GameObject fadingCanvas = null;
	AudioSource music;

	void Awake() {
		if (fadingCanvas == null) {
			DontDestroyOnLoad (gameObject);
			fadingCanvas = gameObject;
			music = GetComponent<AudioSource>();
			music.Play();
		}
		panel = GetComponentInChildren<CanvasGroup> ();
	}

	void OnEnable() {
		SceneManager.sceneUnloaded += FadeScreen;
	}

	void OnDisable() {
		SceneManager.sceneUnloaded -= FadeScreen;
	}

	void FadeScreen(Scene scene) {
		panel.alpha = 1f;
		StartCoroutine ("FadeIn");	
	}

	IEnumerator FadeIn() {
		while (panel.alpha > 0f) {
			panel.alpha -= .1f;
			yield return new WaitForSeconds (.1f);
		}


	}
}
