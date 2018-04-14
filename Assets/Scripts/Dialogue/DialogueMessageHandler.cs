using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMessageHandler : MonoBehaviour, IDialogueMessageHandler
{

	public DialogueManager dManage;

	public void DialogueMessage_OnAwakeInBedroom ()
	{
		CallTrigger ("DM_OnAwakeInBedroom");
	}

	public void DialogueMessage_OnEnterLivingRoom ()
	{
		CallTrigger ("DM_OnEnterLivingRoom");
	}

	public void DialogueMessage_OnEnterParentsRoom ()
	{
		CallTrigger ("DM_OnEnterParentsRoom");
	}

	public void DialogueMessage_OnEnterMainRoad ()
	{
		CallTrigger ("DM_OnEnterMainRoad");
	}

	public void DialogueMessage_OnCompleteTalkingToNeighbors ()
	{
		CallTrigger ("DM_OnCompleteTalkingToNeighbors");
	}

	private void CallTrigger (string childName)
	{
		transform.Find (childName).GetComponent<DialogueTrigger> ().TriggerDialogue (dManage);
	}

	
}
