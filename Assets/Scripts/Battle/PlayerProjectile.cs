using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    EnemyHealth enemyHealth;
    int count;

	// Use this for initialization
	new void Start ()
	{
		base.Start ();
		rb.AddForce (0, 0, speed, ForceMode.VelocityChange);
        enemyHealth = GameObject.FindGameObjectWithTag("NPC").GetComponent<EnemyHealth>();
    }

	void FixedUpdate ()
	{
		//if (count == 20) {
		//	count = 0;
		//} else if (count == 0) {
		//	Debug.Log (transform.position);

		//}
		//count++;
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered");
        if (other.gameObject.tag == "NPC")
        {
            Debug.Log("hit enemy");
            enemyHealth.DecreaseCurrentHealth(1);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player Attack")
        {
            //Debug.Log("hit attack");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
