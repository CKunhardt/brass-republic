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

	public void DialogueMessage_PreventEarlyProceed ()
	{
		CallTriggerDay2 ("DM_PreventEarlyProceed");
	}

	public void DialogueMessage_OnAwake ()
	{
		CallTriggerDay2 ("DM_OnAwake");
	}

	public void DialogueMessage_OnInspectParentsRoom ()
	{
		CallTriggerDay2 ("DM_OnInspectParentsRoom");
	}

	public void DialogueMessage_OnInspectMainRoad ()
	{
		CallTriggerDay2 ("DM_OnInspectMainRoad");
	}

	public void DialogueMessage_Urchin2 ()
	{
		CallTriggerDay2 ("DM_Urchin2");
	}

	public void DialogueMessage_Urchin3 ()
	{
		CallTriggerDay2 ("DM_Urchin3", "NaokiMeeting");
	}

	private void CallTriggerDay2 (string childName, string eventName = null)
	{
		transform.Find ("Day2/" + childName).GetComponent<DialogueTrigger> ().TriggerDialogue (dManage, eventName);
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
