﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawns enemy projectiles at the enemy's location
public class EnemyProjectileSpawner : MonoBehaviour
{

	public Rigidbody projectilePrefab;
	public GameObject Enemy;

	private void Start ()
	{
		Enemy = GameObject.FindGameObjectWithTag ("NPC");
	}

	public void Attack (Vector3 enemyPos)
	{
		Instantiate (projectilePrefab, enemyPos, new Quaternion (0, 0, 0, 0)); // spawn a projectile
	}
}
