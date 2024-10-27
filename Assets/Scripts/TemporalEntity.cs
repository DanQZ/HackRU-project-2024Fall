using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemporalEntity : MonoBehaviour
{
    // static variables are shared across ball instances of the class
    // all temporal entities will share the same max tracking time and start time for the tracking, because we want to be able to 
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

    protected List<Queue> GetSecondsAgo(float secondsAgo, List<Queue> allQs){
        float currentTime = Time.time;
        float targetTime = currentTime - secondsAgo;
        Queue<float> timeQCopy = new Queue<float>(timeQ); 
        
        while(timeQCopy.Count > 0 && timeQCopy.Peek() < targetTime){
            timeQCopy.Dequeue();
            foreach(Queue q in allQs){
                q.Dequeue();

                // if go back before it was created
                if(q.Count == 0){
                    break;
                }
            }
        }
        return allQs;
    }
    
    protected abstract void AddToQueues();
    public abstract void ReverseMyTime(float amount);
}
