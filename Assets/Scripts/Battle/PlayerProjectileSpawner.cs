using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns a projectile at player's location, with shooting delay
public class PlayerProjectileSpawner : MonoBehaviour
{
	public Rigidbody playerProjectilePrefab;
	public GameObject Player;
	bool shooting;
	float shootingDelay;
	float totalShootingDelay;

	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");

		shooting = false;
		totalShootingDelay = 25;
	}

	void FixedUpdate ()
	{        
        //disables shooting until correct tutorial stage
		if (GameManager.Instance.GSV.BattleTutorialStage == 0 || GameManager.Instance.GSV.BattleTutorialStage >= 3) {
			if (Input.GetMouseButtonDown (0) && shooting == false && !GameManager.Instance.inDialogue) {
				shooting = true;
				ShootPlayerProjectile (Player.transform.position.x);
				shootingDelay = 0;
			}

            //if player recently shot, must wait before shooting again
			if (shooting == true) {
				if (shootingDelay < totalShootingDelay)
					shootingDelay++;
				else
					shooting = false;
			}
		}
	}

	void ShootPlayerProjectile (float x)
	{
		Instantiate (playerProjectilePrefab, new Vector3 (x, 0, 0), new Quaternion (0, 0, 0, 0)); // spawn a player attack
	}
}
