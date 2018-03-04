using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2D;
	private Animator anim;
	private float moveSpeed = 0.1f;

	// Use this for initialization
	protected void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	protected void Move (int xDir, int yDir)
	{
		Vector2 newPos = new Vector2(xDir, yDir);
		rb2D.MovePosition(rb2D.position + newPos * moveSpeed);
	}

	
	// Update is called once per frame
	void Update ()
	{
		int horizontal = (int)Input.GetAxisRaw ("Horizontal");
		int vertical = (int)Input.GetAxisRaw ("Vertical");

		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", horizontal);
			anim.SetFloat ("input_y", vertical);
			Move (horizontal, vertical);
		} else {
			anim.SetBool ("isWalking", false);
		}

	}

}
