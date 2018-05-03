using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//controls player taking damage
public class PlayerHealth : MonoBehaviour
{
	public Rigidbody rb;
	GameObject Projectile;
	public float playerHealth;
	SpriteRenderer spriteRend;
	public Slider healthSlider;
	public bool damaged;
	float damageFlash;
	float totalDamageFlash = 20;
	Color normalColor;

	void Start ()
	{
		spriteRend = GetComponent<SpriteRenderer> ();
		playerHealth = 5;
		damaged = false;
		damageFlash = 0;
		normalColor = spriteRend.color;
	}

    //if player took damage recently, flash red
	private void FixedUpdate ()
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

    //if player isn't invulnerable, decrease health and make them invulnerable
	public void DecreaseCurrentHealth (int damage)
	{
		if (GameManager.Instance.GSV.BattleTutorialStage == 0 || GameManager.Instance.GSV.BattleTutorialStage == 5) {
			if (damaged == false) {
				damaged = true;
				playerHealth -= damage;
				healthSlider.value = playerHealth;

				if (playerHealth <= 0) {
					BattleManager.Instance.BattleOver (false);
				}
			}

		} else {
			damaged = true;
			BattleManager.Instance.WrongMove ();
			if (GameManager.Instance.GSV.BattleTutorialStage == 2) {
				BattleManager.Instance.enemyBattle.GetComponent<EnemyMovement> ().attacking = true;
			}
		}
	}
}
