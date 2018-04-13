using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : Interaction, IInteractable {

	public GameObject target;
	private GameObject dialogueBox;
	private DialogueManager dManager;

	new void Start ()
	{
		base.Start();
		dManager = uiCanvas.dialogueManager;
		dialogueBox = dManager.dialogBox;
	}

	public override void Interact ()
	{
		if (target.tag == "NPC" && isInteractable == true) {
			DialogueTrigger dTrig = target.GetComponent<DialogueTrigger> ();
			Entity targetEntity = target.GetComponent<NPC> ();
			Entity playerEntity = currentOther.GetComponentInParent<Player> ();
		
			DialogueEventManager.Instance.player = playerEntity;
			DialogueEventManager.Instance.target = targetEntity;
		
			dialogueBox.SetActive (true);
			dTrig.TriggerDialogue (dManager);
		}
	}
}
