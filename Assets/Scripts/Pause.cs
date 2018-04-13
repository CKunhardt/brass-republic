using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    // current bug where when go to Pause, quickly goes to Main without clicking
    // fixed by uncheking Pause script from PauseMenu component

    public void Main() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Game() {
        SceneManager.LoadScene(GameManager.Instance.lastSceneName);
    }

}
