using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls player's movement via the mouse
public class MouseMovement : MonoBehaviour
{
	public Rigidbody rb;
	GameObject Projectile;

	public bool movementEnabled { get; set; }

	private void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.transform.position = new Vector3 (0, 0, 0);
		Cursor.lockState = CursorLockMode.Confined;
	}

	private void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
		}

        //move player with mouse and check if movement tutorial is completed
		if (movementEnabled) {
			Vector3 movement = new Vector3 (((Input.mousePosition.x / Screen.width) * 20) - 10, 0, 0);
			rb.MovePosition (movement);
			if (GameManager.Instance.GSV.BattleTutorialStage == 1) {
				if (rb.transform.position.x > 9f)
					GameManager.Instance.GSV.MovedRight = true;
				if (rb.transform.position.x < -9f)
					GameManager.Instance.GSV.MovedLeft = true;
				if (GameManager.Instance.GSV.MovedLeft && GameManager.Instance.GSV.MovedRight)
					BattleManager.Instance.ProgressBattle ();
			}
		}

	}
}
