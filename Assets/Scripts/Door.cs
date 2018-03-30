using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable {

	public GameObject target;
	public GameObject dialogueBox;

	private Collider2D currentOther;
	private bool isInteractable = false;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			currentOther = other;
			isInteractable = true;
			Interact();
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			currentOther = null;
			isInteractable = false;
		}
	}

	public void Interact ()
	{
		if (target.tag == "NPC" && isInteractable == true) {
			DialogueTrigger dTrig = target.GetComponent<DialogueTrigger>();
			Entity targetEntity = target.GetComponent<NPC>();
			Entity playerEntity = currentOther.GetComponentInParent<Player>();

			DialogueEventManager.Instance.player = playerEntity;
			DialogueEventManager.Instance.target = targetEntity;

			dialogueBox.SetActive(true);
			dTrig.TriggerDialogue();
		}
	}
}
