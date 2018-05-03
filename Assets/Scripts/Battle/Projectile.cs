using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent class for EnemyProjectile and PlayerProjectile
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

    //when projectile goes offscreen
	protected void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}

}
