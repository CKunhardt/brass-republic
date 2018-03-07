using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!
 
	public Vector2 nextPosition;
 
	void Awake () {
		// Your initialization code here
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		Debug.Log("Setting position: " + nextPosition.x + ", " + nextPosition.y);
		FindObjectOfType<Player> ().SetPosition (nextPosition);
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}