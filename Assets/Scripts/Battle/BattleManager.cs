using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleManager : Singleton<BattleManager>
{
	public GameObject playerBattle;
	public GameObject enemyBattle;

	void Awake ()
	{
		DialogueEventManager.Instance.playerBattle = this.playerBattle.GetComponent<MouseMovement> ();
		DialogueEventManager.Instance.enemyBattle = this.enemyBattle.GetComponent<EnemyMovement> ();
	}

	public void BattleOver (bool win)
	{
		if (win) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_RoyYouWin ());
		} else {
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_RoyYouLose ());
		}
	}

	public void ProgressBattle ()
	{
		switch (GameManager.Instance.GSV.BattleTutorialStage) {
		case 1:
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_RoyDodge ());
			break;
		case 2:
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_RoyAttack ());
			break;
		case 3:
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_RoyCancel ());
			break;
		case 4:
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_RoyFight ());
			break;
		}
	}
}
