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

	public Vector2 pausePosition { get; set; }

	public bool isPaused;
	public bool firstLoad;

	public Canvas uiCanvas;

	public GameStateVariables GSV;
	public GameObject DMH;
	public GameObject EMH;
	public GameObject playerObject;

	void Awake ()
	{
		// Your initialization code here
		SceneManager.sceneLoaded += OnSceneLoaded;
		GSV = new GameStateVariables ();
		DMH = GameObject.Find ("UICanvas/DialogueSystem/DialogueMessageHandler");
		EMH = GameObject.Find ("UICanvas/EventSystem/EventMessageHandler");
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		isPaused = true;
		firstLoad = true;
		DialogueEventManager.Instance.player = playerObject.GetComponent<Entity> ();
		StartCoroutine (WaitForInput (KeyCode.Escape));
	}

	public void Reinitialize ()
	{
		GSV = new GameStateVariables ();
		firstLoad = true;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		if (!isPaused) {
			Vector2 newPosition = GameObject.Find (spawnerName).transform.position;
			FindObjectOfType<Player> ().SetPosition (newPosition);
			ExecuteEvents.Execute<IEventMessageHandler> (EMH, null, (x, y) => x.CheckSceneEvents (scene.name));
		} else if (scene.name != "MainMenu" && scene.name != "PauseMenu" && !firstLoad) {
			FindObjectOfType<Player> ().SetPosition (pausePosition);
			isPaused = false;
		} else if (scene.name != "MainMenu" && scene.name != "PauseMenu" && scene.name != "PlayerScene" && firstLoad) {
			Vector2 newPosition = GameObject.Find (spawnerName).transform.position;
			FindObjectOfType<Player> ().SetPosition (newPosition);
			firstLoad = false;
			isPaused = false;
			ExecuteEvents.Execute<IEventMessageHandler> (EMH, null, (x, y) => x.CheckSceneEvents (scene.name));
		}
	}

	IEnumerator WaitForInput (KeyCode key)
	{
		while (true) {
			yield return StartCoroutine (WaitForKeyDown (key));
			string sceneName = SceneManager.GetActiveScene ().name;
			if (!isPaused) {
				lastSceneName = sceneName;
				pausePosition = playerObject.transform.position;
				isPaused = true;
				SceneManager.LoadScene ("PauseMenu");
			}
		}
	}

	IEnumerator WaitForKeyDown (KeyCode key)
	{
		do {
			yield return null;
		} while (!Input.GetKeyDown (key));
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

}

