using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public EnemyMovement enemyMovement;
    public int enemyHealth;
    SpriteRenderer spriteRend;
    private bool damaged;
    float damagedFlash;
    float damageFlash;
    float totalDamageFlash = 20;
    Color normalColor;

    // Use this for initialization
    void Start () {
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        spriteRend = GetComponent<SpriteRenderer>();
        damaged = false;
        damageFlash = 0;
        normalColor = spriteRend.color;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (damaged == true)
        {
            if (damageFlash < totalDamageFlash)
            {
                spriteRend.color = Color.red;
                damageFlash++;
            }
            else
            {
                spriteRend.color = normalColor;
                damageFlash = 0;
                damaged = false;
            }
        }
    }


    public void DecreaseCurrentHealth(int damage)
    {
        Debug.Log("decrease enemy health");
        enemyHealth -= damage;
        damaged = true;

        if (enemyHealth <= 0)
            {
            enemyMovement.enabled = false;
            //trigger battle end
            }
        }
    }
