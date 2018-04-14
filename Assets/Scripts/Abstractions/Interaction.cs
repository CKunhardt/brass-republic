using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour, IInteractable {

	public bool hasInteraction;

	protected Collider2D currentOther;
	protected UICanvas uiCanvas;
	protected GameObject interactionPrompt;
	protected bool isInteractable = false;

	protected void Start ()
	{
		uiCanvas = GameObject.Find("UICanvas").GetComponent<UICanvas>();
		interactionPrompt = uiCanvas.interactionPrompt;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player" && hasInteraction) {
			currentOther = other;
			isInteractable = true;
			interactionPrompt.SetActive(true);
			StartCoroutine(WaitForInput());
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player" && hasInteraction) {
			currentOther = null;
			isInteractable = false;
			interactionPrompt.SetActive(false);
		}
	}

	IEnumerator WaitForInput ()
	{
		while (isInteractable) {
			yield return StartCoroutine(WaitForKeyDown());
			Interact();
		}
	}

	IEnumerator WaitForKeyDown ()
	{
		do {
			yield return null;
		} while (!Input.GetKeyDown("space"));
	}

	public abstract void Interact();

}
