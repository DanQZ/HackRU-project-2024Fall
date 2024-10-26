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
    }

    protected override void AddToQueues(){
        posQ.Enqueue(transform.position);
    }

    protected override List<Queue> ReversePositionQueue(float amount){
        List<Queue> QList = new List<Queue>();
        QList.Add(posQ);
        QList.Add(HPQ);
        return QList;
    }
}
