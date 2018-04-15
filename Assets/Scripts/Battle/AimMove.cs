using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour
{

    public Rigidbody rb;
    GameObject Player;
    public float speed;
    float step;
    Vector3 playerPos;
    float cameraDistance;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        step = speed * Time.deltaTime;
        rb = GetComponent<Rigidbody>();
        playerPos = Player.transform.position;
        //Debug.Log(playerPos);
        rb.AddForce(playerPos - rb.transform.position);
        cameraDistance = GameObject.FindGameObjectWithTag("MainCamera").transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.position.z < cameraDistance)
        {
            Destroy(this);
        }
        rb.AddForce(playerPos - rb.transform.position);
        //Debug.Log(rb.position.z);
    }

}