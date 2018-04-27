using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

	public int enemyHealth;
	SpriteRenderer spriteRend;
	private bool damaged;
	float damagedFlash;
	float damageFlash;
	float totalDamageFlash = 20;
	Color normalColor;

	// Use this for initialization
	void Start ()
	{
		spriteRend = GetComponent<SpriteRenderer> ();
		damaged = false;
		damageFlash = 0;
		normalColor = spriteRend.color;

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (damaged == true) {
			if (damageFlash < totalDamageFlash) {
				spriteRend.color = Color.red;
				damageFlash++;
			} else {
				spriteRend.color = normalColor;
				damageFlash = 0;
				damaged = false;
			}
		}
	}


	public void DecreaseCurrentHealth (int damage)
	{
		if (GameManager.Instance.GSV.BattleTutorialStage == 0 || GameManager.Instance.GSV.BattleTutorialStage == 5)
			enemyHealth -= damage;
		damaged = true;

		if (GameManager.Instance.GSV.BattleTutorialStage == 3)
			BattleManager.Instance.ProgressBattle ();

		if (enemyHealth <= 0) {
			BattleManager.Instance.BattleOver (true);
		}
	}
}
