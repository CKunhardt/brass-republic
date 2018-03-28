using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
	public string spawnerName;
 
	void Awake () {
		// Your initialization code here
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		Vector2 newPosition = GameObject.Find(spawnerName).transform.position;
		FindObjectOfType<Player> ().SetPosition (newPosition);
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}