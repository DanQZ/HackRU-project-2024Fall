using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemporalEntity : MonoBehaviour
{
    // static variables are shared across ball instances of the class
    // all temporal entities will share the same max tracking time and start time for the tracking, because we want to be able to 
    private static float maxTrackingTime = 5f;
    private static float posQStartTime = 0f;

    // this queue stores the time at which each new queue's element was added, since all 
    // this is used to determine how far back in time we remove elements from the queue
    private Queue<float> timeQ = new Queue<float>();

    void Start()
    {
        TemporalEntityManager.instance.AddTemporalEntity(this);
    }

    void OnDestroy()
    {
        TemporalEntityManager.instance.RemoveTemporalEntity(this);
    }

    // UpdateQueue is called by the TemporalEntityManager every frame
    public void UpdateQueue(){
        AddToQueues();
    }

    // adds all the necessary information to the queues

    public void ReverseTime(float amount){
        if(amount > maxTrackingTime){
            amount = maxTrackingTime;
        }
        ReversePositionQueue(amount);
    }
    
    protected abstract void AddToQueues();
    protected abstract void ReversePositionQueue(float amount);
}
