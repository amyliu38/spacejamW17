using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

    Animator anim;
    public bool moveRL;
    public bool moveUD;
    Transform player; 
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        if (moveRL)
        {
            anim.SetTrigger("MoveRL");
        }
        if (moveUD)
        {
            anim.SetTrigger("MoveUD");
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit; // hit is the object that is contact with ray
        if (Physics.SphereCast(transform.position, .5f, transform.up, out hit, 5f))
        {
            //if there is an object in ray
            player = hit.transform; //player is now the actual player object
            //player.parent is null before this point
            //transform is the platform's transform
            player.parent = transform; //player is now set as a child of the platform's transform
        }
        else if(player != null) //If ray is no longer cast, and player != null
        {
            player.parent = null;
            player = null;
        }
	}
}
