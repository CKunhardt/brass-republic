using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hit : MonoBehaviour {

    GameObject Player;
    GameObject projectile;
    PlayerHealth playerHealth;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered");
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("hit player");
            playerHealth.DecreaseCurrentHealth(1);
            Destroy(this.gameObject);


        }
    }
}
