using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventMessageHandler : MonoBehaviour, IEventMessageHandler
{

	public void CheckSceneEvents (string sceneName)
	{
		switch (sceneName) {
		case "YourBedroom":
			if (!GameManager.Instance.GSV.AwokeInRoom) {
				GameManager.Instance.playerObject.GetComponent<Entity> ().SetDirection ("y", -1f);
				FadeManager.Instance.StartFade (true);
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
			} else if (GameManager.Instance.GSV.GameState == 2 && !GameManager.Instance.GSV.TalkedToNaoki) {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnInspectMainRoad ());
			}
			break;
		case "SleeperCar":
			if (!GameManager.Instance.GSV.MetTheGang) {
				GameManager.Instance.GSV.MetTheGang = true;
			}
			break;
		case "BattleSystem":
			GameManager.Instance.playerObject.SetActive (false);
			GameManager.Instance.comingFromBattle = true;
			break;
		}
	}

	public void CheckDialogueEvents (string targetName)
	{
		if (targetName == "Neighbor 1" && !GameManager.Instance.GSV.TalkedToN1) {
			GameManager.Instance.GSV.TalkedToN1 = true;
		} else if (targetName == "Neighbor 2" && !GameManager.Instance.GSV.TalkedToN2) {
			GameManager.Instance.GSV.TalkedToN2 = true;
		} else if (targetName == "YourBed") {
			if (GameManager.Instance.GSV.ReenteredBedroom && GameManager.Instance.GSV.GameState == 1) {
				StartCoroutine (GoToSleep ());
			} else {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnTriggerBed ());
			}
		}
	}

	private IEnumerator GoToSleep ()
	{
		yield return FadeManager.Instance.StartFadeOutAndInAsync ();
		GameManager.Instance.GSV.GameState = 2;
		ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnAwake ());
	}

	public void CheckCustomEvents (string eventName)
	{
		switch (eventName) {
		case "NaokiMeeting":
			GameManager.Instance.GSV.TalkedToNaoki = true;
			break;
		case "RoyDodgeDone":
			GameManager.Instance.GSV.BattleTutorialStage = 2;
			BattleManager.Instance.enemyBattle.GetComponent<EnemyMovement> ().attacking = true;
			break;
		case "RoyAttackDone":
			GameManager.Instance.GSV.BattleTutorialStage = 3;
			break;
		case "RoyCancelDone":
			GameManager.Instance.GSV.BattleTutorialStage = 4;
			BattleManager.Instance.enemyBattle.GetComponent<EnemyMovement> ().attacking = true;
			break;
		case "RoyFightDone":
			GameManager.Instance.GSV.BattleTutorialStage = 5;
			BattleManager.Instance.enemyBattle.GetComponent<EnemyMovement> ().attacking = true;
			break;
		case "GameOver":
			GameManager.Instance.Reinitialize ();
			SceneManager.LoadScene ("MainMenu");
			break;
		}
	}
}
