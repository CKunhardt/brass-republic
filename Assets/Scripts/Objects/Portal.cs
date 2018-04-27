using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{

	public string sceneName, spawnerName;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			if (sceneName == "MainMenu") {
				GameManager.Instance.spawnerName = spawnerName;
				GameManager.Instance.lastSceneName = SceneManager.GetActiveScene ().name;
				SceneManager.LoadScene (sceneName);
			} else {
				StartCoroutine (PrepareLoad ());
			}
		} else {
			other.gameObject.SetActive (false);
		}
	}

	IEnumerator PrepareLoad ()
	{
		GameManager.Instance.playerObject.GetComponent<Entity> ().setMovementEnabled (false);
		yield return FadeManager.Instance.StartFadeAsync (false);
		GameManager.Instance.spawnerName = spawnerName;
		GameManager.Instance.lastSceneName = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (sceneName);
	}
}