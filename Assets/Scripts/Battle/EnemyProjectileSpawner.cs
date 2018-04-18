using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileSpawner : MonoBehaviour
{

	public Rigidbody projectilePrefab;
    public GameObject Enemy;

    private void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("NPC");
    }

    // Update is called once per frame
    void Update ()
	{
        //AttackOnSpace(Enemy.transform.position);

	}

    void AttackOnSpace(Vector3 enemyPos) //testing
    {
        if (Input.GetKeyDown("space"))
        {
            Rigidbody projectileInstance = Instantiate(projectilePrefab, enemyPos, new Quaternion(0, 0, 0, 0));// as Rigidbody;
        }
    }

    public void Attack(Vector3 enemyPos)
    {
        Rigidbody projectileInstance = Instantiate(projectilePrefab, enemyPos, new Quaternion(0, 0, 0, 0));
    }
}
