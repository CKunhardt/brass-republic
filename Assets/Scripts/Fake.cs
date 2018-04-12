using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fake : MonoBehaviour {

    public void Pause() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        // if Game is 2 in build and Pause is 1

    }

}
