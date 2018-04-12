using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        // if Game is 0 in build and Menu is 4
    }

    public void QuitGame() {
        Debug.Log("quit");
        Application.Quit();
    }

}
