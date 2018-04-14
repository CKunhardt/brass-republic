using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public void NavigateMain ()
	{
		GameManager.Instance.Reinitialize ();
		SceneManager.LoadScene ("MainMenu");
	}

	public void NavigateGame ()
	{
		SceneManager.LoadScene (GameManager.Instance.lastSceneName);
	}

}
