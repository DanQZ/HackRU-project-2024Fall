using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemporalEntity : MonoBehaviour
{
    // static variables are shared across ball instances of the class
    // all temporal entities will share the same max tracking time and start time for the tracking, because we want to be able to 

    // this queue stores the time at which each new queue's element was added, since all 
    // this is used to determine how far back in time we remove elements from the queue
    protected Queue<float> timeQ = new Queue<float>();

    protected float lastReversedTime;
    protected float timeToCullQs;
    protected void Start()
    {
        lastReversedTime = Time.time;
        TemporalEntityManager.instance.AddTemporalEntity(this);
    }

    protected void OnDestroy()
    {
        TemporalEntityManager.instance.RemoveTemporalEntity(this);

    }

    // UpdateQueue is called by the TemporalEntityManager every frame
    public void UpdateQueue(){
        AddToQueues();
        timeQ.Enqueue(Time.time);
        if(timeQ.Count > 0){
            while(timeQ.Peek() < Time.time - TemporalEntityManager.maxTrackingTime){
                timeQ.Dequeue();
                DequeueQueues();
            }
        }
    }

    protected Queue<T> GetReversedTimeValue<T>(Queue<T> q){
        float currentTime = Time.time;
        float targetTime = currentTime - TemporalEntityManager.maxTrackingTime;
        Queue<float> timeQCopy = new Queue<float>(timeQ);
        
        while(timeQCopy.Count > 0 && timeQCopy.Peek() < targetTime){
            timeQCopy.Dequeue();
            q.Dequeue();
        }

        return q;
    }

    public void ClearTimeQ(){
        timeQ.Clear();
    }
    
    public void ReverseTime(){
        lastReversedTime = Time.time;
        timeQ.Clear();
        SetReversedTimeValues();
        CullQueues();
    }

    // add the current state of the entity to the queues
    protected abstract void AddToQueues();

    // remove the oldest element from the queues
    protected abstract void DequeueQueues();

    // set values to the state they were from GetSecondsAgo
    public abstract void SetReversedTimeValues();

    // clear all the queues
    protected abstract void CullQueues();
}
