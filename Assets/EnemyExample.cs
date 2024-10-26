using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExample : TemporalEntity
{
    float speed = 2f;

    float HP = 100f;

    Queue<Vector3> posQ = new Queue<Vector3>();
    Queue<float> HPQ = new Queue<float>();
    
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

    protected override List<Queue<T>> ReversePositionQueue(float amount){
        return new List<Queue<T>>{posQ, HPQ};
    }
}
