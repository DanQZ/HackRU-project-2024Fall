using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingEnemy : BasicEnemy
{
    private float moveSpeed = 2f;
    private float targetDistance = 5f;
    void Start(){
        interval = 0.2f;
    }
    void Update()
    {
        AttemptToShoot();
        Movement();
    }

    void Movement(){
        Vector3 moveVector = new Vector3( // go at
            player.position.x - transform.position.x,
            player.position.y - transform.position.y,
            0f
        );

        Vector3 moveVectorCircle = new Vector3( // go circle
            -1f * moveVector.y,
            moveVector.x,
            0f
        );

        float distanceToPlayer = Vector3.Distance(player.position, this.gameObject.transform.position);

        Vector3 trueMoveDistance = moveVector * Time.deltaTime * moveSpeed * Mathf.Abs(distanceToPlayer - targetDistance) * 0.25f;
        if (targetDistance < distanceToPlayer)
        {
            transform.position += trueMoveDistance;
        }
        else
        {
            transform.position -= trueMoveDistance;
        }

        transform.position += moveVectorCircle * Time.deltaTime * moveSpeed;
    }
}
