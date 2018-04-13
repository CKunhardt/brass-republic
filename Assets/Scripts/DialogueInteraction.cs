using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueInteraction : Interaction, IInteractable
{

	public GameObject target;
	private DialogueManager dManager;

	new void Start ()
	{
		base.Start ();
		dManager = uiCanvas.dialogueManager;
	}

	public override void Interact ()
	{
		if (target.tag == "NPC" && isInteractable == true) {
			DialogueTrigger dTrig = target.GetComponent<DialogueTrigger> ();
			Entity targetEntity = target.GetComponent<NPC> ();
			Entity playerEntity = currentOther.GetComponentInParent<Player> ();
		
			DialogueEventManager.Instance.player = playerEntity;
			DialogueEventManager.Instance.target = targetEntity;

			if (target.name == "Neighbor 1") {
				GameManager.Instance.GSV.TalkedToN1 = true;
				if (GameManager.Instance.GSV.TalkedToN2 && !GameManager.Instance.GSV.CompletedTalkingToNeighbors) {
					ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnCompleteTalkingToNeighbors ());
					GameManager.Instance.GSV.CompletedTalkingToNeighbors = true;
				}
			}
			if (target.name == "Neighbor 2") {
				GameManager.Instance.GSV.TalkedToN2 = true;
				if (GameManager.Instance.GSV.TalkedToN1 && !GameManager.Instance.GSV.CompletedTalkingToNeighbors) {
					ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnCompleteTalkingToNeighbors ());
					GameManager.Instance.GSV.CompletedTalkingToNeighbors = true;
				}
			}
		
			dTrig.TriggerDialogue (dManager);
		}
	}
}
