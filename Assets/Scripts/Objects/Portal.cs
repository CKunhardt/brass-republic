using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{

	public string sceneName, spawnerName;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (sceneName == "MainMenu") {
			GameManager.Instance.spawnerName = spawnerName;
			GameManager.Instance.lastSceneName = SceneManager.GetActiveScene ().name;
			SceneManager.LoadScene (sceneName);
		} else {
			StartCoroutine (PrepareLoad ());
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