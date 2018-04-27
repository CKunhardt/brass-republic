using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		//Debug.Log(Player);

		shooting = false;
		totalShootingDelay = 40;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{        
		if (GameManager.Instance.GSV.BattleTutorialStage == 0 || GameManager.Instance.GSV.BattleTutorialStage >= 3) {
			if (Input.GetMouseButtonDown (0) && shooting == false) {
				shooting = true;
				ShootPlayerProjectile (Player.transform.position.x);
				shootingDelay = 0;
			}

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
		Instantiate (playerProjectilePrefab, new Vector3 (x, 0, 0), new Quaternion (0, 0, 0, 0)); // Spawn a player attack
	}
}
