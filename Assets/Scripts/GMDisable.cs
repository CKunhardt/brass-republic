using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMDisable : Interaction {

	public GameObject[] targets;

	private GameObject[] disabledObjects;
	private bool disabledState;

	new void Start(){
		base.Start();
		disabledObjects = new GameObject[targets.Length];
		disabledState = false;
	}


	public override void Interact ()
	{
		if (!disabledState) {
			int i = 0;
			foreach (GameObject obj in targets) {
				disabledObjects [i] = obj;
				obj.SetActive (false);
				i++;
			}
			disabledState = true;
		} else {
			int i = 0;
			foreach (GameObject obj in disabledObjects) {
				disabledObjects[i].SetActive(true);
				disabledObjects[i] = null;
				i++;
			}
			disabledState = false;
		}
	}


}
