﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

	// Use this for initialization
	protected void Start ()
	{
		DontDestroyOnLoad (this);
		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		horizontal = 0;
		vertical = 0;
		movementEnabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (movementEnabled) {
			handleMovement ();
		}
	}

	protected override void handleMovement ()
	{
		horizontal = (int)Input.GetAxisRaw ("Horizontal");
		vertical = (int)Input.GetAxisRaw ("Vertical");

		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", horizontal);
			anim.SetFloat ("input_y", vertical);
			Move (horizontal, vertical);
		} else {
			anim.SetBool ("isWalking", false);
			fixFlying ();
		}
	}

}
