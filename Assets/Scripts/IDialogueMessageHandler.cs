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
}
