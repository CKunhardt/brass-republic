using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IDialogueMessageHandler : IEventSystemHandler
{

	// Define all automatic dialogue triggers here

	// General Triggers

	void DialogueMessage_OnTriggerBed ();

	void DialogueMessage_NeighborSilence ();

	// Day 1 Triggers

	void DialogueMessage_OnAwakeInBedroom ();

	void DialogueMessage_OnEnterLivingRoom ();

	void DialogueMessage_OnEnterParentsRoom ();

	void DialogueMessage_OnEventParentsBed ();

	void DialogueMessage_OnEnterMainRoad ();

	void DialogueMessage_OnTriggerNeighbor1 ();

	void DialogueMessage_OnTriggerNeighbor2 ();

	void DialogueMessage_OnCompleteTalkingToNeighbors ();

	void DialogueMessage_OnReenterBedroom ();


	// Day 2 Triggers

	void DialogueMessage_PreventEarlyProceed ();

	void DialogueMessage_OnAwake ();

	void DialogueMessage_OnInspectParentsRoom ();

	void DialogueMessage_OnInspectMainRoad ();

	void DialogueMessage_Urchin2 ();

	void DialogueMessage_Urchin3 ();

	void DialogueMessage_Naoki1 ();

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
