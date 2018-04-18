using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
	PlayerHealth playerHealth;
	Vector3 playerPos;

	// Use this for initialization
	new void Start ()
	{
		base.Start ();
		playerHealth = player.GetComponent<PlayerHealth>();
		playerPos = player.transform.position;
		rb.AddForce ((playerPos.x - rb.transform.position.x), 0, -speed, ForceMode.VelocityChange);
	}

	void FixedUpdate ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		//Debug.Log("triggered");
		if (other.gameObject.tag == "Player") {
			//Debug.Log("hit player");
			playerHealth.DecreaseCurrentHealth (1);
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Player Attack") {
			//Debug.Log("hit attack");
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}


}
