using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IEventMessageHandler : IEventSystemHandler
{
	void CheckSceneEvents (string sceneName);

	void CheckDialogueEvents (string targetName);

	void CheckCustomEvents (string eventName);

	IEnumerator EnterBattle ();
}
