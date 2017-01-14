using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBridgeFront : InteractTileBase {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Open()
    {
        anim.SetBool("FrontLower", true);
    }

    public override void Close()
    {
        anim.SetBool("FrontLower", false);
    }
}
