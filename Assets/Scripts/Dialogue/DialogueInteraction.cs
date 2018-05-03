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
		if (isInteractable == true) {
			DialogueTrigger dTrig = target.GetComponent<DialogueTrigger> ();
			Entity targetEntity = target.GetComponent<NPC> ();
			Entity playerEntity = currentOther.GetComponentInParent<Player> ();
		
			DialogueEventManager.Instance.player = playerEntity;
			DialogueEventManager.Instance.target = targetEntity;

			ExecuteEvents.Execute<IEventMessageHandler> (GameManager.Instance.EMH, null, (x, y) => x.CheckDialogueEvents (target.name));
		
			//dTrig.TriggerDialogue (dManager);
		}
	}
}
