using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

	protected Rigidbody2D rb2D;
	protected Animator anim;
	protected float moveSpeed = 0.1f;
	protected int horizontal, vertical;

	protected void Move (int xDir, int yDir)
	{
		Vector2 newPos = new Vector2(xDir, yDir);
		rb2D.MovePosition(rb2D.position + newPos * moveSpeed);
	}

	public void SetPosition (Vector2 newPos)
	{
		rb2D.position = newPos;
		Debug.Log("New position: " + rb2D.position.x + ", " + rb2D.position.y);
	}

	protected void fixFlying ()
	{
		rb2D.velocity = Vector2.zero;
	}
}
