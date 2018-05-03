using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls projectiles sent by the player
public class PlayerProjectile : Projectile
{
	EnemyHealth enemyHealth;

	new void Start ()
	{
		base.Start ();
		rb.AddForce (0, 0, speed, ForceMode.VelocityChange);
		enemyHealth = GameObject.FindGameObjectWithTag ("NPC").GetComponent<EnemyHealth> ();
	}

	void OnTriggerEnter (Collider other)
	{
		// Hit Enemy
		if (other.gameObject.tag == "NPC") {
			enemyHealth.DecreaseCurrentHealth (1);
			if (GameManager.Instance.GSV.BattleTutorialStage == 4) {
				BattleManager.Instance.WrongMove ();
			}
			Destroy (gameObject);
		}

		// Cancelled Attacak
		if (other.gameObject.tag == "Player Attack") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
