using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalEntityManager : MonoBehaviour
{   
    //singleton 
    public static TemporalEntityManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private static float maxTrackingTime = 10f;
    private List<TemporalEntity> temporalEntities = new List<TemporalEntity>();
    
    // have all the temporal entities update their queues per update
    void Update()
    {
        foreach(TemporalEntity entity in temporalEntities)
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

    public void ReverseTime(float amount){
        foreach(TemporalEntity entity in temporalEntities)
        {
            entity.ReverseMyTime(amount);
        }
    }
}
