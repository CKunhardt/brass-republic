using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity {

	int framebuffer;
	public bool isMoveable;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		framebuffer = 0;
		horizontal = 0;
		vertical = 0;
		moveSpeed = 0.05f;
		isInDialogue = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isInDialogue && isMoveable) {
			handleMovement();
		}
	}

	protected override void handleMovement ()
	{
		framebuffer++;

		if (framebuffer == 20) {

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
