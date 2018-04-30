using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderTrigger : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			if (GameManager.Instance.GSV.GameState == 1 && !GameManager.Instance.GSV.TriggeredParentsEvent && gameObject.name == "ColliderTriggerEventParentsBed") {
				GameManager.Instance.GSV.TriggeredParentsEvent = true;
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnEventParentsBed ());
                Debug.Log("noooo");

            } else if (!GameManager.Instance.GSV.CompletedTalkingToNeighbors && GameManager.Instance.GSV.TalkedToN1 && GameManager.Instance.GSV.TalkedToN2) {
				GameManager.Instance.GSV.CompletedTalkingToNeighbors = true;
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnCompleteTalkingToNeighbors ());

            } else if (GameManager.Instance.GSV.GameState == 2 && !GameManager.Instance.GSV.ReenteredParentsRoom) {
				GameManager.Instance.GSV.ReenteredParentsRoom = true;
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnInspectParentsRoom ());

            } else if (GameManager.Instance.GSV.GameState == 2 && !GameManager.Instance.GSV.TalkedToNaoki && gameObject.name == "NaokiColliderTrigger1") {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_Urchin2 ());

            } else if (GameManager.Instance.GSV.GameState == 2 && !GameManager.Instance.GSV.TalkedToNaoki && gameObject.name == "NaokiColliderTrigger2") {
				ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_Urchin3 ());
			}
		} 
	}
}
