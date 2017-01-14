using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathandRespawn : MonoBehaviour {

	public GameObject Corpse;
	Transform Respawn_Platform;
	// Use this for initialization
	void Start () {
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
		this.transform.position = Respawn_Platform.position + new Vector3 (0, 10, 0);
		GetComponent<PlayerMovement>().restartJump ();
	}

	public void Death(){
		
		Vector3 pos = this.transform.position + new Vector3(0,1f,0);
		GameObject corp = Instantiate (Corpse, pos, Corpse.transform.rotation);
		//corp.GetComponent<Rigidbody> ().velocity = Vector3.zero;

		Respawn ();
	}








}
