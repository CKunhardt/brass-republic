﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("TestScene");
	}
}
