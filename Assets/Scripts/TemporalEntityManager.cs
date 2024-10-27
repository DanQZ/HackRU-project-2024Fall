using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalEntityManager : MonoBehaviour
{
    //singleton 
    public static TemporalEntityManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static float maxTrackingTime { get; private set; } = 0.5f;
    public static float nextAvailableTimeReverseTime { get; set; } = 0f;
    private List<TemporalEntity> temporalEntities = new List<TemporalEntity>();


    void Start()
    {

    }

    // have all the temporal entities update their queues per update
    void Update()
    {
        foreach (TemporalEntity entity in temporalEntities)
        {
            entity.UpdateQueue();
        }
    }

    // AddTemporalEntity and RemoveTemporalEntity are called by the TemporalEntity class upon instantiation and destruction
    public void AddTemporalEntity(TemporalEntity entity)
    {
        temporalEntities.Add(entity);
    }
    public void RemoveTemporalEntity(TemporalEntity entity)
    {
        temporalEntities.Remove(entity);
    }

    public void ReverseTime()
    {
        if (!CanReverseTime()) { return; }
        foreach (TemporalEntity entity in temporalEntities)
        {
            entity.ReverseTime();
        }
        nextAvailableTimeReverseTime = Time.time + maxTrackingTime;
    }

    public bool CanReverseTime(){
        return Time.time > nextAvailableTimeReverseTime;
    }
}
