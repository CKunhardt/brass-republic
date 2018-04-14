using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollow : MonoBehaviour {

	public GameObject objectToFollow;

	void Start () {
		transform.position = objectToFollow.transform.position;
	}
	
	void FixedUpdate () {
		transform.position = objectToFollow.transform.position;
	}
}
