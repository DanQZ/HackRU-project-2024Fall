using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExample : TemporalEntity
{
    float speed = 2f;

    float HP = 100f;

    [SerializeField] GameObject graphic2; // for debugging 
    [SerializeField] private Queue<Vector3> posQ = new Queue<Vector3>();
    private Queue<float> HPQ = new Queue<float>();

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        graphic2.transform.position = posQ.Peek();
    }

    // add the current position and HP to the queues
    protected override void AddToQueues(){
        Debug.Log($"Enqueueing {transform.position}");
        posQ.Enqueue(transform.position);
        HPQ.Enqueue(HP);
    }

    // remove the oldest element from each queue
    protected override void DequeueQueues(){
        posQ.Dequeue();
        HPQ.Dequeue();
    }

    // just clear all the queues
    protected override void CullQueues(){
        posQ.Clear();
        HPQ.Clear();
    }

    // set values to the state they were from GetReversedTimeValue<T>(Queue<T> q)
    // use peek
    public override void SetReversedTimeValues(){
        posQ = GetReversedTimeValue<Vector3>(posQ);
        transform.position = posQ.Peek();

        HPQ = GetReversedTimeValue<float>(HPQ);
        HP = HPQ.Peek();
    }
}
