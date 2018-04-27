using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMessageHandler : MonoBehaviour, IDialogueMessageHandler
{

	public DialogueManager dManage;

	// General Triggers

	public void DialogueMessage_OnTriggerBed ()
	{
		CallTrigger ("DM_OnTriggerBed");
	}

	private void CallTrigger (string childName, string eventName = null)
	{
		transform.Find (childName).GetComponent<DialogueTrigger> ().TriggerDialogue (dManage, eventName);
	}

	// Day 1 Triggers

	public void DialogueMessage_OnAwakeInBedroom ()
	{
		CallTriggerDay1 ("DM_OnAwakeInBedroom");
	}

	public void DialogueMessage_OnEnterLivingRoom ()
	{
		CallTriggerDay1 ("DM_OnEnterLivingRoom");
	}

	public void DialogueMessage_OnEnterParentsRoom ()
	{
		CallTriggerDay1 ("DM_OnEnterParentsRoom");
	}

	public void DialogueMessage_OnEnterMainRoad ()
	{
		CallTriggerDay1 ("DM_OnEnterMainRoad");
	}

	public void DialogueMessage_OnCompleteTalkingToNeighbors ()
	{
		CallTriggerDay1 ("DM_OnCompleteTalkingToNeighbors");
	}

	public void DialogueMessage_OnReenterBedroom ()
	{
		CallTriggerDay1 ("DM_OnReenterBedroom");
	}

	private void CallTriggerDay1 (string childName, string eventName = null)
	{
		transform.Find ("Day1/" + childName).GetComponent<DialogueTrigger> ().TriggerDialogue (dManage, eventName);
	}

	// Day 2 Triggers

	// Battle Triggers

	public void DialogueMessage_MarleyIntro ()
	{
		CallBattleTrigger ("DM_MarleyIntro");
	}

	public void DialogueMessage_RoyDodge ()
	{
		CallBattleTrigger ("DM_RoyDodge", "RoyDodgeDone");
	}

	public void DialogueMessage_RoyAttack ()
	{
		CallBattleTrigger ("DM_RoyAttack", "RoyAttackDone");
	}

	public void DialogueMessage_RoyCancel ()
	{
		CallBattleTrigger ("DM_RoyCancel", "RoyCancelDone");
	}

	public void DialogueMessage_RoyFight ()
	{
		CallBattleTrigger ("DM_RoyFight", "RoyFightDone");
	}

	public void DialogueMessage_RoyWrong ()
	{
		CallBattleTrigger ("DM_RoyWrong");
	}

	public void DialogueMessage_RoyYouWin ()
	{
		CallBattleTrigger ("DM_RoyYouWin", "GameOver");
	}

	public void DialogueMessage_RoyYouLose ()
	{
		CallBattleTrigger ("DM_RoyYouLose", "GameOver");
	}

	private void CallBattleTrigger (string childName, string eventName = null)
	{
		transform.Find ("BattleDialogue/" + childName).GetComponent<DialogueTrigger> ().TriggerDialogue (dManage, eventName);
	}





	
}
