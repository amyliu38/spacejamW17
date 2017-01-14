using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractTileBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public abstract void Open ();

	public abstract void Close ();
}
