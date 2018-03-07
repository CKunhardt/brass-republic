using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour {

	public string sceneName;
	public float x;
	public float y;

	void OnTriggerEnter2D (Collider2D other)
	{
		GameManager.Instance.nextPosition = new Vector2(x, y);
		SceneManager.LoadScene(sceneName);
	}
}