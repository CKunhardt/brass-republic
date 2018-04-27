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

	public void DialogueMessage_OnReenterBedroom ()
	{
		CallTrigger ("DM_OnReenterBedroom");
	}

	public void DialogueMessage_OnTriggerBed ()
	{
		CallTrigger ("DM_OnTriggerBed");
	}

	private void CallTrigger (string childName, string eventName = null)
	{
		transform.Find (childName).GetComponent<DialogueTrigger> ().TriggerDialogue (dManage, eventName);
	}

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
