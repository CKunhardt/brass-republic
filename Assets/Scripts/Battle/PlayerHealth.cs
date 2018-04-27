using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start ()
	{
		spriteRend = GetComponent<SpriteRenderer> ();
		playerHealth = 5;
		damaged = false;
		damageFlash = 0;
		normalColor = spriteRend.color;
	}

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
		}
	}
}
