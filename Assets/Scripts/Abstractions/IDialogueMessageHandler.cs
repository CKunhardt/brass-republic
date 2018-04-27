using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDialogueMessageHandler : IEventSystemHandler
{

	// Define all automatic dialogue triggers here
	void DialogueMessage_OnAwakeInBedroom ();

	void DialogueMessage_OnEnterLivingRoom ();

	void DialogueMessage_OnEnterParentsRoom ();

	void DialogueMessage_OnEnterMainRoad ();

	void DialogueMessage_OnCompleteTalkingToNeighbors ();

	void DialogueMessage_OnReenterBedroom ();

	void DialogueMessage_OnTriggerBed ();

	// Battle Triggers

	void DialogueMessage_MarleyIntro ();

	void DialogueMessage_RoyDodge ();

	void DialogueMessage_RoyAttack ();

	void DialogueMessage_RoyCancel ();

	void DialogueMessage_RoyFight ();

	void DialogueMessage_RoyWrong ();

	void DialogueMessage_RoyYouWin ();

	void DialogueMessage_RoyYouLose ();
}
