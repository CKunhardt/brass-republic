using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public Image icon;
	public GameObject dialogBox;

	private Queue<string> sentences;

	// Use this for initialization
	void Start ()
	{
		sentences = new Queue<string> ();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		dialogBox.SetActive (true);
		DialogueEventManager.Instance.diagEvent.Invoke (true);

		nameText.text = dialogue.name;
		icon.overrideSprite = dialogue.avatar;

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
		dialogBox.SetActive (false);
		DialogueEventManager.Instance.diagEvent.Invoke (false);
	}




}
