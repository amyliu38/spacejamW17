using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class DeathandRespawn : MonoBehaviour {
    AudioSource sound;
	public GameObject Corpse;
	Transform Respawn_Platform;
	// Use this for initialization

	int Lives = 4;

	void Start () {
        sound = GetComponent<AudioSource>();
		Respawn_Platform = GameObject.FindGameObjectWithTag ("SpawnPoint").transform;

	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -15) {
			//print ("Respawn");
			Respawn ();
		}
	}


	public void Respawn(){
		this.transform.position = Respawn_Platform.position + new Vector3 (0, 20, 0);
		GetComponent<PlayerMovement>().restartJump ();
	}

	public void Death(){
		Lives--;

		if (Lives == 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		} 
		Vector3 pos = this.transform.position + new Vector3 (0, 1f, 0);
		GameObject corp = Instantiate (Corpse, pos, Corpse.transform.rotation);
		Respawn ();
        sound.Play();
    }
}
