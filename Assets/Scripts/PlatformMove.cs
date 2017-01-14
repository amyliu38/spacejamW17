﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

    Animator anim;
    public bool moveRL;
    public bool moveUD;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moveRL)
        {
            anim.SetTrigger("MoveRL");
        }
        if (moveUD)
        {
            anim.SetTrigger("MoveUD");
        }
	}
}