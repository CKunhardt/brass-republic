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

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(Player);

        shooting = false;
        totalShootingDelay = 40;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //this.GetComponent<Rigidbody>().position = Player.transform.position;
        
        if (Input.GetKey("s") && shooting == false)
        {
            shooting = true;
            Debug.Log("S");
            ShootPlayerProjectile(Player.transform.position.x);
            Debug.Log("spawn");
            shootingDelay = 0;
        }

        if (shooting == true)
        {
            if (shootingDelay < totalShootingDelay)
                shootingDelay++;
            else
                shooting = false;
        }
    }

    void ShootPlayerProjectile(float x)
    {
        Rigidbody playerProjectileInstance = Instantiate(playerProjectilePrefab, new Vector3(x, 0, 0), new Quaternion(0, 0, 0, 0));// as Rigidbody;
    }
}
