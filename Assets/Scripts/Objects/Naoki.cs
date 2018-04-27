using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Naoki : NPC
{
	private GameObject naokiTarget;
	private GameObject naokiTarget2;
	private bool startedMoving;
	private Vector2 startPosition;
	private Vector2 destination;
	private float journeyLength;
	private float startTime;
	private float speed;
	private int walkSegment;

	new void Start ()
	{
		base.Start ();
		startedMoving = false;
		speed = 5;
		walkSegment = 1;
		naokiTarget = GameObject.Find ("NaokiTarget");
		if (SceneManager.GetActiveScene ().name == "EngineCar") {
			naokiTarget2 = GameObject.Find ("Spawner_SleeperCar");
		}
	}

	void Update ()
	{
		if (GameManager.Instance.GSV.TalkedToNaoki) {
			if (SceneManager.GetActiveScene ().name == "MainRoad") {
				GameManager.Instance.playerObject.GetComponent<Entity> ().setMovementEnabled (false);
				FirstWalk ();
			} else if (SceneManager.GetActiveScene ().name == "EngineCar") {
				if (walkSegment == 1)
					FirstWalk ();
				else if (walkSegment == 2)
					SecondWalk ();
			}
		} else if (SceneManager.GetActiveScene ().name != "SleeperCar") {
			anim.SetFloat ("input_x", -1f);
		} else {
			fixFlying ();
		}
	}

	private void FirstWalk ()
	{
		if (!startedMoving) {
			anim.SetFloat ("input_x", -1f);
			startPosition = transform.position;
			startTime = Time.time;
			destination = naokiTarget.transform.position;
			journeyLength = Vector2.Distance (transform.position, destination);
			startedMoving = true;
			anim.SetBool ("isWalking", true);
		}
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector2.Lerp (startPosition, destination, fracJourney);
		if (fracJourney > .95f) {
			GameManager.Instance.playerObject.GetComponent<Entity> ().setMovementEnabled (true);
			walkSegment++;
			startedMoving = false;
			anim.SetBool ("isWalking", false);
		}
	}

	private void SecondWalk ()
	{
		if (!startedMoving) {
			startPosition = transform.position;
			startTime = Time.time;
			destination = naokiTarget2.transform.position;
			journeyLength = Vector2.Distance (transform.position, destination);
			startedMoving = true;
			anim.SetBool ("isWalking", true);
			anim.SetFloat ("input_x", 0f);
			anim.SetFloat ("input_y", 1f);
		}
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector2.Lerp (startPosition, destination, fracJourney);
	}

}
