using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float leftXBound;
    public float rightXBound;
    Vector3 moveDestination;
    public float initialSpeed;
    private float speed;
    private Vector3 lastPosition;
    private Vector3 startPosition;
    private float startTime;
    private float journeyLength;
    private float startPush;
    bool attacking;

    public EnemyProjectileSpawner enemyProjectileSpawner;



	// Use this for initialization
	void Start () {
        lastPosition = transform.position;
        speed = initialSpeed;
        attacking = false;

        //enemyProjectileSpawner = gameObject.GetComponent<EnemyProjectileSpawner>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (transform.position == lastPosition)
        {
            startTime = Time.time;
            moveDestination = new Vector3(((rightXBound - leftXBound) * Random.value) - 5, 0, this.transform.position.z);
            startPosition = transform.position;
            journeyLength = Vector3.Distance(transform.position, moveDestination);
            startPush = 0.001f;

            if (attacking)
            {
                enemyProjectileSpawner.Attack(transform.position);
                speed += 0.1f;
            }
        }

        lastPosition = transform.position;
        float distCovered = (Time.time - startTime) * speed + startPush;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, moveDestination, fracJourney);
        startPush = 0;

        //if (moving == false)
        //{
        //    moveDestination = new Vector3(((rightXBound - leftXBound) * Random.value), 0, this.transform.position.z);
        //    moving = true;
        //    if (this.transform.position.x < moveDestination.x)
        //        movingRight = true;
        //    else
        //        movingRight = false;
        //}
        //else if (moving == true)
        //{
        //    //if ((this.transform.position.x > moveDestination.x && movingRight) 
        //    //    || (this.transform.position.x < moveDestination.x && !movingRight))
        //    //{
        //    //    moving = false;
        //    //}
        //    else
        //    {
        //        rb.MovePosition(moveDestination);

        //    }
        //}
    }
}
