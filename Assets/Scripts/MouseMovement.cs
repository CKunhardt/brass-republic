using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    public Rigidbody rb;
    GameObject Projectile;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody> ();
        rb.transform.position = new Vector3(0, 0, 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        Vector3 movement = new Vector3(Input.mousePosition.x/200, Input.mousePosition.y/200, 0);
        rb.MovePosition(movement);
    }

}
