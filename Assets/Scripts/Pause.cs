using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    // current bug where when go to Pause, quickly goes to Main without clicking
    // fixed by uncheking Pause script from PauseMenu component

    public void Main() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // if Pause is 3 in build and Menu is 4
    }

    public void Game() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        // if Pause is 3 in build and Game is 0
    }

}
