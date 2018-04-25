using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity
{

	public bool isMoveable;

	int framebuffer;
	int initialSortingOrder;

	// Use this for initialization
	protected void Start ()
	{
		rb2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		framebuffer = 0;
		horizontal = 0;
		vertical = 0;
		moveSpeed = 0.05f;
		movementEnabled = true;
		initialSortingOrder = GetComponent<SpriteRenderer> ().sortingOrder;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (movementEnabled && isMoveable) {
			handleMovement ();
		}
	}

	protected override void handleMovement ()
	{
		framebuffer++;

		if (framebuffer == 30) {

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
			fixFlying ();
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			GetComponent<SpriteRenderer> ().sortingOrder = other.GetComponent<SpriteRenderer> ().sortingOrder + 1;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			GetComponent<SpriteRenderer> ().sortingOrder = initialSortingOrder;
		}
	}

}
