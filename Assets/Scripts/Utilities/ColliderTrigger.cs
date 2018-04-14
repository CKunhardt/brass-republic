using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderTrigger : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player" && GameManager.Instance.GSV.CompletedTalkingToNeighbors) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnCompleteTalkingToNeighbors ());
		}
	}
}
