using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public GameObject target;
	public GameObject dialogueBox;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (target.tag == "NPC" && other.tag == "Player") {
			DialogueTrigger dTrig = target.GetComponent<DialogueTrigger>();
			dialogueBox.SetActive(true);
			dTrig.TriggerDialogue();
		}
	}
}
