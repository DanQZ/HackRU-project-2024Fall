using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : TemporalEntity
{

//would is be useful to be able to set the damage and speed for
//buffs or debuffs?
    public float damage { get; set; } = 10f;
    public float speed { get; set; } = 10f;



    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //Have the bullet move at a constant rate
        transform.Translate(Vector3.up * speed/3 * Time.deltaTime);

        //Destroy the bullet after 8 seconds
        Destroy(gameObject, 8f);
    }

    Queue<Vector3> positionQueue = new Queue<Vector3>();

    public override void SetReversedTimeValues()
    {
        positionQueue = GetReversedTimeValue<Vector3>(positionQueue);
        transform.position = positionQueue.Peek();
    }

    protected override void AddToQueues()
    {
        positionQueue.Enqueue(transform.position);
    }

    protected override void CullQueues()
    {
        positionQueue.Clear();
    }

    protected override void DequeueQueues()
    {
        positionQueue.Dequeue();
    }



}

