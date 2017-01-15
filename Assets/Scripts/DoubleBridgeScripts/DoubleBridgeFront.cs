using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBridgeFront : InteractTileBase
{

    Animator anim;
    public AudioClip bridgeDown;
    public AudioClip bridgeUp;
    public AudioClip bridgeContact;
    AudioSource sound;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Open()
    {
        anim.SetBool("FrontLower", true);
    }

    public override void Close()
    {
        anim.SetBool("FrontLower", false);
    }
    public override void SoundDown()
    {
        sound.clip = bridgeDown;
        sound.Play();
    }

    public override void SoundUp()
    {
        sound.clip = bridgeUp;
        sound.Play();
    }

    public override void SoundContact()
    {
        sound.clip = bridgeContact;
        sound.Play();
    }
}
