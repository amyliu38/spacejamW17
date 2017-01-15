using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

	public InteractTileBase[] linkedTile;
	bool opened = false;
	Animator anim; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	/*void Update () {
		RaycastHit hit;

		if (Physics.SphereCast (transform.position, .5f, transform.up, out hit, 10f)) {
		//if(Physics.Raycast(transform.position, transform.up, 3f)){
			//trigger some function, door or drawbridge etc
			if(!opened){
				linkedTile.Open ();
				opened = true;
				anim.SetBool ("down", opened);
				Debug.Log ("down");
			}
		} else if(opened){
			linkedTile.Close ();
			opened = false;
			anim.SetBool ("down", opened);
			Debug.Log ("up");
		}
	}*/

	void OnTriggerStay(){
		if (!opened) {
			foreach (InteractTileBase lt in linkedTile)
			{
				lt.Open();
				anim.SetBool("down", true);
				opened = true;
			}
		}
       
	}

    void OnTriggerExit()
    {
        foreach (InteractTileBase lt in linkedTile)
        {
            lt.Close();
            anim.SetBool("down", false);
			opened = false;
        }
    }
}
