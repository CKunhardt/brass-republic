using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderTrigger : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player" && !GameManager.Instance.GSV.CompletedTalkingToNeighbors && GameManager.Instance.GSV.TalkedToN1 && GameManager.Instance.GSV.TalkedToN2) {
			GameManager.Instance.GSV.CompletedTalkingToNeighbors = true;
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_OnCompleteTalkingToNeighbors ());
		}
	}
}
