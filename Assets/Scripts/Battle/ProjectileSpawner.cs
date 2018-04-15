using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

    public Rigidbody projectilePrefab;

	// Update is called once per frame
	void Update () {

        //testing
		if (Input.GetKeyDown("space"))
        {
            Rigidbody projectileInstance = Instantiate(projectilePrefab, this.transform) as Rigidbody;
        }
	}
}
