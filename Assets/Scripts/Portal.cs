using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour {

	public string sceneName, spawnerName;

	void OnTriggerEnter2D (Collider2D other)
	{
		GameManager.Instance.spawnerName = spawnerName;
		SceneManager.LoadScene(sceneName);
	}
}