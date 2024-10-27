using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingEnemy : BasicEnemy
{
    [SerializeField] private Transform previousGraphic;
    private float moveSpeed = 1f;
    private float targetDistance = 5f;
    
    protected void Start(){
        base.Start();
        interval = 0.5f;
    }
    protected void Update()
    {
        base.Update();
        AttemptToShoot();
        Movement();
        previousGraphic.position = posQ.Peek();
    }

    private void Movement(){
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
    
    Queue<Vector3> posQ = new Queue<Vector3>();
    // add the current state of the entity to the queues
    protected override void AddToQueues(){
        Debug.Log($"Enqueueing {transform.position}");
        posQ.Enqueue(transform.position);
    }

    // remove the oldest element from the queues
    protected override void DequeueQueues(){
        posQ.Dequeue();
    }
    
    // set values to the state they were from GetSecondsAgo
    public override void SetReversedTimeValues(){

        posQ = GetReversedTimeValue<Vector3>(posQ);
        transform.position = posQ.Peek();
    }

    // clear all the queues
    protected override void CullQueues(){
        posQ.Clear();
    }
}
