using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
	public DialogueTrigger nextDialogue;

	public void TriggerDialogue (DialogueManager dManage, string eventName = null)
	{
		if (nextDialogue != null && eventName != null) {
			dManage.StartDialogue (dialogue, nextDialogue, eventName);
		} else if (nextDialogue != null) {
			dManage.StartDialogue (dialogue, nextDialogue);
		} else if (eventName != null) {
			dManage.StartDialogue (dialogue, null, eventName);
		} else {
			dManage.StartDialogue (dialogue);
		}
	}


}
