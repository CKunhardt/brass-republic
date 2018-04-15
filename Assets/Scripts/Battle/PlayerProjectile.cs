using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{

	int count;

	// Use this for initialization
	new void Start ()
	{
		base.Start ();
		rb.AddForce (0, 0, speed, ForceMode.VelocityChange);
	}

	void FixedUpdate ()
	{
		if (count == 20) {
			count = 0;
		} else if (count == 0) {
			Debug.Log (transform.position);

		}
		count++;
	}

}
