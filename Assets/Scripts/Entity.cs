using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

	protected Rigidbody2D rb2D;
	protected Animator anim;
	protected float moveSpeed = 0.1f;
	protected int horizontal, vertical;
	protected bool isInDialogue;

	protected void Move (int xDir, int yDir)
	{
		Vector2 newPos = new Vector2(xDir, yDir);
		rb2D.MovePosition(rb2D.position + newPos * moveSpeed);
	}

	protected abstract void handleMovement();

	public void setIsInDialogue (bool state)
	{
		isInDialogue = state;
	}

	public void SetPosition (Vector2 newPos)
	{
		rb2D.position = newPos;
	}

	public void fixFlying ()
	{
		rb2D.velocity = Vector2.zero;
		anim.SetBool("isWalking", false);
	}
}
