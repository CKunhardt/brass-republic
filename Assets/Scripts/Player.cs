using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2D;
	private float moveSpeed = 0.1f;

	// Use this for initialization
	protected void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}

	protected void Move (int xDir, int yDir)
	{
		Vector2 newPos = new Vector2(rb2D.position.x + xDir * moveSpeed, rb2D.position.y + yDir * moveSpeed);
		rb2D.MovePosition(newPos);
	}

	
	// Update is called once per frame
	void Update ()
	{
		int horizontal = (int)Input.GetAxisRaw ("Horizontal");
		int vertical = (int)Input.GetAxisRaw ("Vertical");

		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0) {
			Move(horizontal, vertical);
		}
	}

}
