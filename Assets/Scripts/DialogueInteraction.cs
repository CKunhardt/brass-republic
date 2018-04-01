﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : MonoBehaviour, IInteractable {

	public GameObject target;


	public bool hasInteraction;

	private Collider2D currentOther;
	private GameObject dialogueBox;
	private GameObject interactionPrompt;
	private DialogueManager dManage;

	private bool isInteractable = false;

	void Start ()
	{
		dManage = GameObject.Find("UICanvas/DialogueManager").GetComponent<DialogueManager>();
		dialogueBox = dManage.dialogBox;
		interactionPrompt = dManage.interactionPrompt;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player" && hasInteraction) {
			currentOther = other;
			isInteractable = true;
			interactionPrompt.SetActive(true);
			StartCoroutine(WaitForInput());
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player" && hasInteraction) {
			currentOther = null;
			isInteractable = false;
			interactionPrompt.SetActive(false);
		}
	}

	IEnumerator WaitForInput ()
	{
		while (isInteractable) {
			yield return StartCoroutine(WaitForKeyDown());
			Interact();
		}
	}

	IEnumerator WaitForKeyDown ()
	{
		do {
			yield return null;
		} while (!Input.GetKeyDown("space"));
	}

	public void Interact ()
	{
		if (target.tag == "NPC" && isInteractable == true) {
			DialogueTrigger dTrig = target.GetComponent<DialogueTrigger> ();
			Entity targetEntity = target.GetComponent<NPC> ();
			Entity playerEntity = currentOther.GetComponentInParent<Player> ();
		
			DialogueEventManager.Instance.player = playerEntity;
			DialogueEventManager.Instance.target = targetEntity;
		
			dialogueBox.SetActive (true);
			dTrig.TriggerDialogue (dManage);
		}
	}
}
