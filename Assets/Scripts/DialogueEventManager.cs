using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEventManager : Singleton<DialogueEventManager> {

	protected DialogueEventManager () {}

	private Entity playerInternal;
	private Entity targetInternal;
	public Entity player {
		get {
			return this.playerInternal;
		}
		set {
			playerInternal = value;
		}
	}
	public Entity target {
		get {
			return this.targetInternal;
		}
		set {
			targetInternal = value;
		}
	}

	public DialogueEvent diagEvent;

	void Awake ()
	{
		if(diagEvent == null)
			diagEvent = new DialogueEvent();

		diagEvent.AddListener(ChangeDialogueState);
	}

	void ChangeDialogueState (bool state)
	{
		playerInternal.setIsInDialogue (state);
		playerInternal.fixFlying();
		targetInternal.setIsInDialogue (state);
		targetInternal.fixFlying();

		if (state == false) {
			player = null;
			target = null;
		}
	}
}

public class DialogueEvent : UnityEvent<bool> {
	
}
