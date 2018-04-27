using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void PlayGame ()
	{
		GameManager.Instance.lastSceneName = "YourBedroom";
		GameManager.Instance.spawnerName = "Spawner_Start";
		FadeManager.Instance.image.gameObject.SetActive (true);
		SceneManager.LoadScene (GameManager.Instance.lastSceneName);
	}

	public void QuitGame ()
	{
		Debug.Log ("quit");
		Application.Quit ();
	}

}
