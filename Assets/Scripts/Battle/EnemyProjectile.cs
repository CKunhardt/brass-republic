using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//controls projectiles sent from enemy
public class EnemyProjectile : Projectile
{
	PlayerHealth playerHealth;
	Vector3 playerPos;

	new void Start ()
	{
		base.Start ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerPos = player.transform.position;
		rb.AddForce ((playerPos.x - rb.transform.position.x), 0, -speed, ForceMode.VelocityChange);
	}

	void OnTriggerEnter (Collider other)
	{
        //if collides with player, player takes damage and projectile destroys
		if (other.gameObject.tag == "Player") {
			playerHealth.DecreaseCurrentHealth (1);
			Destroy (gameObject);
		}

        //if collides with a player attack, destroy both projectiles
		if (other.gameObject.tag == "Player Attack") {
			if (GameManager.Instance.GSV.BattleTutorialStage == 4) {
				BattleManager.Instance.ProgressBattle ();
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

	new protected void OnBecameInvisible ()
	{
		if (GameManager.Instance.GSV.BattleTutorialStage == 2 && !playerHealth.damaged) {
			BattleManager.Instance.ProgressBattle ();
		}
		base.OnBecameInvisible ();
	}


}
