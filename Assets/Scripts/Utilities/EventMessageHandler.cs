using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventMessageHandler : MonoBehaviour, IEventMessageHandler
{

	public void CheckSceneEvents (string sceneName)
	{
		if (sceneName == "YourBedroom" && !GameManager.Instance.GSV.AwokeInRoom) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnAwakeInBedroom ());
			GameManager.Instance.GSV.AwokeInRoom = true;
		} else if (sceneName == "LivingRoom" && !GameManager.Instance.GSV.EnteredLivingRoom) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnEnterLivingRoom ());
			GameManager.Instance.GSV.EnteredLivingRoom = true;
		} else if (sceneName == "ParentsBedroom" && !GameManager.Instance.GSV.EnteredParentsRoom) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnEnterParentsRoom ());
			GameManager.Instance.GSV.EnteredParentsRoom = true;
		} else if (sceneName == "MainRoad" && !GameManager.Instance.GSV.EnteredMainRoad) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnEnterMainRoad ());
			GameManager.Instance.GSV.EnteredMainRoad = true;
		}
	}

	public void CheckDialogueEvents (string targetName)
	{
		if (targetName == "Neighbor 1" && !GameManager.Instance.GSV.TalkedToN1) {
			GameManager.Instance.GSV.TalkedToN1 = true;
			if (GameManager.Instance.GSV.TalkedToN2 && !GameManager.Instance.GSV.CompletedTalkingToNeighbors) {
				GameManager.Instance.GSV.CompletedTalkingToNeighbors = true;
			}
		}
		if (targetName == "Neighbor 2" && !GameManager.Instance.GSV.TalkedToN2) {
			GameManager.Instance.GSV.TalkedToN2 = true;
			if (GameManager.Instance.GSV.TalkedToN1 && !GameManager.Instance.GSV.CompletedTalkingToNeighbors) {
				GameManager.Instance.GSV.CompletedTalkingToNeighbors = true;
			}
		}	
	}
}
