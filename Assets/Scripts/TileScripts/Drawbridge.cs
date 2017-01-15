using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawbridge : InteractTileBase
{

    AudioSource sound;
    Animator anim;

    public AudioClip bridgeUp;
    public AudioClip bridgeDown;
    public AudioClip bridgeContact;
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
        anim.SetBool("down", true);
    }

    public override void Close()
    {
        anim.SetBool("down", false);
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

