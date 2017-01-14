using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBridgeBack : InteractTileBase {

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
        anim.SetBool("BackLower", true);
    }

    public override void Close()
    {
        anim.SetBool("BackLower", false);
    }
}
