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
		SceneManager.LoadScene (GameManager.Instance.lastSceneName);
	}

	public void QuitGame ()
	{
		Debug.Log ("quit");
		Application.Quit ();
	}

}
