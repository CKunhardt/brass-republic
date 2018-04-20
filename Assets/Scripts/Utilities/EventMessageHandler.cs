using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventMessageHandler : MonoBehaviour, IEventMessageHandler
{

	public void CheckSceneEvents (string sceneName)
	{
		switch (sceneName) {
		case "YourBedroom":
			if (!GameManager.Instance.GSV.AwokeInRoom) {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnAwakeInBedroom ());
				GameManager.Instance.GSV.AwokeInRoom = true;
			}
			if (!GameManager.Instance.GSV.ReenteredBedroom && GameManager.Instance.GSV.CompletedTalkingToNeighbors) {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnReenterBedroom ());
				GameManager.Instance.GSV.ReenteredBedroom = true;
			}
			break;
		case "LivingRoom":
			if (!GameManager.Instance.GSV.EnteredLivingRoom) {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnEnterLivingRoom ());
				GameManager.Instance.GSV.EnteredLivingRoom = true;
			}
			break;
		case "ParentsBedroom":
			if (!GameManager.Instance.GSV.EnteredParentsRoom) {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnEnterParentsRoom ());
				GameManager.Instance.GSV.EnteredParentsRoom = true;
			}
			break;
		case "MainRoad":
			if (!GameManager.Instance.GSV.EnteredMainRoad) {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnEnterMainRoad ());
				GameManager.Instance.GSV.EnteredMainRoad = true;
			}
			break;
		case "BattleSystemTest":
			GameManager.Instance.playerObject.SetActive (false);
			GameManager.Instance.comingFromBattle = true;
			break;
		}

	}

	public void CheckDialogueEvents (string targetName)
	{
		if (targetName == "Neighbor 1" && !GameManager.Instance.GSV.TalkedToN1) {
			GameManager.Instance.GSV.TalkedToN1 = true;
		}
		if (targetName == "Neighbor 2" && !GameManager.Instance.GSV.TalkedToN2) {
			GameManager.Instance.GSV.TalkedToN2 = true;
		}	
	}
}
