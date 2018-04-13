using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : Singleton<GameManager>
{
	protected GameManager ()
	{
	}
	// guarantee this will be always a singleton only - can't use the constructor!

	public class GameStateVariables
	{
		public bool AwokeInRoom,
			EnteredLivingRoom,
			EnteredParentsRoom,
			EnteredMainRoad,
			TalkedToN1,
			TalkedToN2,
			CompletedTalkingToNeighbors;

		public int GameState;

		public GameStateVariables ()
		{
			AwokeInRoom = false;
			EnteredLivingRoom = false;
			EnteredParentsRoom = false;
			EnteredMainRoad = false;
			TalkedToN1 = false;
			TalkedToN2 = false;
			CompletedTalkingToNeighbors = false;

			GameState = 1;
		}
	}

	private string _spawnerName;

	public string spawnerName {
		get { return this._spawnerName; }
		set { _spawnerName = value; }
	}

    public string lastSceneName { get; set; }

	public Canvas uiCanvas;

	public GameStateVariables GSV;
	public GameObject DMH;

	void Awake ()
	{
        // Your initialization code here
        lastSceneName = "PlayerScene";
        spawnerName = "Spawner_Menu";
		SceneManager.sceneLoaded += OnSceneLoaded;
		GSV = new GameStateVariables ();
		DMH = GameObject.Find ("UICanvas/DialogueSystem/DialogueMessageHandler");
		DialogueEventManager.Instance.player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Entity> ();
        StartCoroutine(WaitForInput(KeyCode.Escape));
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		Vector2 newPosition = GameObject.Find (spawnerName).transform.position;
		FindObjectOfType<Player> ().SetPosition (newPosition);
		if (scene.name == "YourBedroom" && !GSV.AwokeInRoom) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (DMH, null, (x, y) => x.DialogueMessage_OnAwakeInBedroom ());
			GSV.AwokeInRoom = true;
		} else if (scene.name == "LivingRoom" && !GSV.EnteredLivingRoom) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (DMH, null, (x, y) => x.DialogueMessage_OnEnterLivingRoom ());
			GSV.EnteredLivingRoom = true;
		} else if (scene.name == "ParentsBedroom" && !GSV.EnteredParentsRoom) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (DMH, null, (x, y) => x.DialogueMessage_OnEnterParentsRoom ());
			GSV.EnteredParentsRoom = true;
		} else if (scene.name == "MainRoad" && !GSV.EnteredMainRoad) {
			ExecuteEvents.Execute<IDialogueMessageHandler> (DMH, null, (x, y) => x.DialogueMessage_OnEnterMainRoad ());
			GSV.EnteredMainRoad = true;
		}
	}

    IEnumerator WaitForInput(KeyCode key) {
        while (true) {
            yield return StartCoroutine(WaitForKeyDown(key));
            lastSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("PauseMenu");
        }
    }

    IEnumerator WaitForKeyDown(KeyCode key) {
        do {
            yield return null;
        } while (!Input.GetKeyDown(key));
    }

    void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

}

