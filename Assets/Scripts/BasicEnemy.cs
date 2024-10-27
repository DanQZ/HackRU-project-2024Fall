using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : TemporalEntity
{
    protected float timer = 0;
    protected float interval = 1.5f;
    protected float inaccuracy = 10f;

    protected Transform player => GameManager.instance.playerInstance.transform;
    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    protected void Update()
    {
        if (player == null) {
            return;
        }
        transform.right = player.position - transform.position;
        AttemptToShoot();
    }

    protected void AttemptToShoot () {
        //check if the time is greater than the interval
        if(Time.time > timer){
            //turn to face the player
            //transform.LookAt(Player.instance.transform);

            //shoot at the player
            ShootAtPlayer();
            //reset the timer
            timer = Time.time + interval;
        }
    }

    [SerializeField] GameObject bulletPrefab;
    protected void ShootAtPlayer () {
        //Create bullet object
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.transform.up = player.position - transform.position;

        //apply inaccuracy 
        bullet.transform.Rotate(0, 0, Random.Range(-inaccuracy, inaccuracy));
    }

    // add the current state of the entity to the queues
    protected override void AddToQueues(){

    }

    // remove the oldest element from the queues
    protected override void DequeueQueues(){

    }
    
    // set values to the state they were from GetSecondsAgo
    public override void SetReversedTimeValues(){

    }

    // clear all the queues
    protected override void CullQueues(){

    }
}
