using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Image h1;
    public Image h2;
    public Image h3;
    public Image caution;
    DeathandRespawn player;
    int lives_remaining;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DeathandRespawn>();
        caution.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        lives_remaining = player.getLives();
        if(lives_remaining == 3)
        {
            h3.enabled = false;
        }
        else if(lives_remaining == 2)
        {
            h2.enabled = false;
        }
        else if(lives_remaining == 1)
        {
            h1.enabled = false;
            caution.enabled = true;
        }
	}
}
