using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity {

	int framebuffer;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		framebuffer = 0;
		horizontal = 0;
		vertical = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{

		framebuffer++;

		if (framebuffer == 10) {

			horizontal = (int)Mathf.Floor (Random.Range (-1, 2));
			vertical = (int)Mathf.Floor (Random.Range (-1, 2));

			framebuffer = 0;
		}

		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", horizontal);
			anim.SetFloat ("input_y", vertical);
			Move (horizontal, vertical);
		} else {
			anim.SetBool ("isWalking", false);
			fixFlying();
		}


		
	}
}
