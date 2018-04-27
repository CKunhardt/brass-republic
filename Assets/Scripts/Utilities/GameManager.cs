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
			CompletedTalkingToNeighbors,
			ReenteredBedroom,
			MovedLeft,
			MovedRight;

		public int GameState,
			BattleTutorialStage;

		public GameStateVariables ()
		{
			AwokeInRoom = false;
			EnteredLivingRoom = false;
			EnteredParentsRoom = false;
			EnteredMainRoad = false;
			TalkedToN1 = false;
			TalkedToN2 = false;
			CompletedTalkingToNeighbors = false;
			ReenteredBedroom = false;
			MovedLeft = false;
			MovedRight = false;

			GameState = 1;
			BattleTutorialStage = 1;
		}
	}

	public List<string> pauseLevels;

	private string _spawnerName;

	public string spawnerName {
		get { return this._spawnerName; }
		set { _spawnerName = value; }
	}

	public string lastSceneName { get; set; }

	public Vector2 pausePosition { get; set; }

	public bool isPaused;
	public bool firstLoad;
	public bool comingFromBattle;

	public Canvas uiCanvas;

	public GameStateVariables GSV;
	public GameObject DMH;
	public GameObject EMH;
	public GameObject playerObject;

	void Awake ()
	{
		// Your initialization code here
		PopulatePauseLevels ();
		SceneManager.sceneLoaded += OnSceneLoaded;
		GSV = new GameStateVariables ();
		DMH = GameObject.Find ("UICanvas/DialogueSystem/DialogueMessageHandler");
		EMH = GameObject.Find ("UICanvas/EventSystem/EventMessageHandler");
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		isPaused = true;
		firstLoad = true;
		comingFromBattle = false;
		DialogueEventManager.Instance.player = playerObject.GetComponent<Entity> ();
		StartCoroutine (WaitForInput (KeyCode.Escape));
		StartCoroutine (WaitForInput (KeyCode.F1));
	}

	public void Reinitialize ()
	{
		GSV = new GameStateVariables ();
		firstLoad = true;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		if (!isPaused) { // Most loads fall under this category
			Vector2 newPosition = GameObject.Find (spawnerName).transform.position;
			playerObject.GetComponent<Player> ().SetPosition (newPosition);
			StartCoroutine (SceneLoadEvents (scene.name));
		} else if (!pauseLevels.Contains (scene.name) && !firstLoad) { // Game was paused, we're coming from a menu or battle
			if (comingFromBattle) {
				playerObject.SetActive (true);
				comingFromBattle = false;
			}
			playerObject.GetComponent<Player> ().SetPosition (pausePosition);
			isPaused = false;
		} else if (!pauseLevels.Contains (scene.name) && scene.name != "PlayerScene" && firstLoad) { // Game was paused since this was the first load.
			Vector2 newPosition = GameObject.Find (spawnerName).transform.position;
			playerObject.GetComponent<Player> ().SetPosition (newPosition);
			firstLoad = false;
			isPaused = false;
			ExecuteEvents.Execute<IEventMessageHandler> (EMH, null, (x, y) => x.CheckSceneEvents (scene.name));
		} else { // Loading a pause level
			if (scene.name == "MainMenu" && comingFromBattle) {
				playerObject.SetActive (true);
				comingFromBattle = false;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			ExecuteEvents.Execute<IEventMessageHandler> (EMH, null, (x, y) => x.CheckSceneEvents (scene.name));
		}
	}

	IEnumerator SceneLoadEvents (string sceneName)
	{
		if (sceneName == "MainRoad" && GameManager.Instance.GSV.GameState > 1) {
			GameObject.Find ("RoadblocksLeft").SetActive (false);
		}
		yield return FadeManager.Instance.StartFadeAsync (true);
		GameManager.Instance.playerObject.GetComponent<Entity> ().setMovementEnabled (true);
		ExecuteEvents.Execute<IEventMessageHandler> (EMH, null, (x, y) => x.CheckSceneEvents (sceneName));
	}

	IEnumerator WaitForInput (KeyCode key)
	{
		while (true) {
			yield return StartCoroutine (WaitForKeyDown (key));
			if (key == KeyCode.Escape) {
				string sceneName = SceneManager.GetActiveScene ().name;
				if (!isPaused) {
					PrepareForPause (sceneName);
					SceneManager.LoadScene ("PauseMenu");
				}
			} else if (key == KeyCode.F1) {
				string sceneName = SceneManager.GetActiveScene ().name;
				if (!comingFromBattle && !isPaused) {
					PrepareForPause (sceneName);
					SceneManager.LoadScene ("BattleSystem");
				} else if (comingFromBattle) {
					SceneManager.LoadScene (lastSceneName);
				}
			}
		}
	}

	IEnumerator WaitForKeyDown (KeyCode key)
	{
		do {
			yield return null;
		} while (!Input.GetKeyDown (key));
	}

	private void PrepareForPause (string sceneName)
	{
		lastSceneName = sceneName;
		pausePosition = playerObject.transform.position;
		isPaused = true;
	}

	private void PopulatePauseLevels ()
	{
		if (pauseLevels == null) {
			pauseLevels = new List<string> ();
			pauseLevels.Add ("MainMenu");
			pauseLevels.Add ("PauseMenu");
			pauseLevels.Add ("BattleSystemTest");
			pauseLevels.Add ("BattleSystem");
		}
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

}

