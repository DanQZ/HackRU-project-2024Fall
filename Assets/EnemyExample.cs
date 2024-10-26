using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExample : TemporalEntity
{
    float speed = 2f;

    float HP = 100f;

    Queue posQ = new Queue();
    Queue HPQ = new Queue();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        if(Input.GetKeyDown(KeyCode.Space)){
            ReverseMyTime(2f);
        }
    }

    protected override void AddToQueues(){
        posQ.Enqueue(transform.position);
    }

    public override void ReverseMyTime(float seconds){
        // make a new list of queues
        List<Queue> QList = new List<Queue>();

        // add relevant queues to list
        QList.Add(posQ);
        QList.Add(HPQ);

        // get the values of the queues at the time x seconds ago
        QList = GetSecondsAgo(seconds, QList);
        
        // update the position and HP
        HP = (float)HPQ.Peek();
        transform.position = (Vector3)posQ.Peek();
    }
}
