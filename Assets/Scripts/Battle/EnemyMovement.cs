using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//controls enemy's random movement and attacking
public class EnemyMovement : MonoBehaviour
{
	public float leftXBound;
	public float rightXBound;
	public float initialSpeed;

	public bool attacking { get; set; }

	public bool movementEnabled { get; set; }

	private Vector3 moveDestination;
	private Vector3 lastPosition;
	private Vector3 startPosition;

	private float speed;
	private float startTime;
	private float journeyLength;
	private float startPush;


	public EnemyProjectileSpawner enemyProjectileSpawner;

	void Start ()
	{
		lastPosition = transform.position;
		speed = initialSpeed;
		attacking = false;

		if (GameManager.Instance.GSV.BattleTutorialStage == 1) {
			BattleManager.Instance.playerBattle.GetComponent<MouseMovement> ().movementEnabled = true;
			ExecuteEvents.Execute<IDialogueMessageHandler> (GameManager.Instance.DMH, null, (x, y) => x.DialogueMessage_MarleyIntro ());
		}
	}
	
	void FixedUpdate ()
    { 
		if (movementEnabled) {
			switch (GameManager.Instance.GSV.BattleTutorialStage) {
			case 1: // RoyMove event
				Move ();
				break;
			case 2: // RoyDodge event
				if (attacking) {
					enemyProjectileSpawner.Attack (transform.position);
					attacking = false;
				}
				break;
			case 3: // RoyAttack event
				Move ();
				break;
			case 4: // RoyCancel event
				Move ();
				break;
			case 5: // RoyFight event
				Move ();
				break;
			}
		}
	}

	void Move ()
	{
        //if reached destination, determine a new one and shoot
		if (transform.position == lastPosition) {
			startTime = Time.time;
			moveDestination = new Vector3 (((rightXBound - leftXBound) * Random.value) - 5, 0, this.transform.position.z);
			startPosition = transform.position;
			journeyLength = Vector3.Distance (transform.position, moveDestination);
			startPush = 0.001f;

			if (attacking) {
				enemyProjectileSpawner.Attack (transform.position);
                if (speed < 6)
				speed += 0.1f;
			}
		}

        //move towards destination
		lastPosition = transform.position;
		float distCovered = (Time.time - startTime) * speed + startPush;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (startPosition, moveDestination, fracJourney);
		startPush = 0;
	}
}
