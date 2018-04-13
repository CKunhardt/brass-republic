using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour {

	public GameObject interactionPrompt;
	public DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

}
