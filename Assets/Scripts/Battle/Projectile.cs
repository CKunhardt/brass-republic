using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
	protected GameObject player;
	protected GameObject enemy;
	public float speed;
	protected Rigidbody rb;

	protected void Start ()
	{
		player = BattleManager.Instance.playerBattle;
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	protected void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}

}
