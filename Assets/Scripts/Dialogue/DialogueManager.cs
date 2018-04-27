using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public Image icon;
	public GameObject dialogBox;

	private Queue<string> sentences;
	private DialogueTrigger nextDialogue;
	private string eventName;

	// Use this for initialization
	void Start ()
	{
		sentences = new Queue<string> ();
	}

	public void StartDialogue (Dialogue dialogue, DialogueTrigger nextDialogue = null, string eventName = null)
	{
		dialogBox.SetActive (true);
		DialogueEventManager.Instance.diagEvent.Invoke (true);

		nameText.text = dialogue.name;
		icon.overrideSprite = dialogue.avatar;

		this.nextDialogue = nextDialogue;
		this.eventName = eventName;

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		dialogueText.text = sentence;
	}

	void EndDialogue ()
	{
		if (nextDialogue != null && eventName != null) {
			nextDialogue.TriggerDialogue (this, eventName);
		} else if (nextDialogue != null) {
			nextDialogue.TriggerDialogue (this);
		} else if (eventName != null) {
			dialogBox.SetActive (false);
			DialogueEventManager.Instance.diagEvent.Invoke (false);
			ExecuteEvents.Execute<IEventMessageHandler> (GameManager.Instance.EMH, null, (x, y) => x.CheckCustomEvents (eventName));
		} else {
			dialogBox.SetActive (false);
			DialogueEventManager.Instance.diagEvent.Invoke (false);
		}
	}

	IEnumerator WaitForInput ()
	{
		while (true) {
			yield return WaitForKeyDown (KeyCode.Space);
			DisplayNextSentence ();
		}
	}

	IEnumerator WaitForKeyDown (KeyCode key)
	{
		do {
			yield return null;
		} while (!Input.GetKeyDown (key));
	}


}
