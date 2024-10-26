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

    private static float maxTrackingTime = 5f;
    private List<TemporalEntity> temporalEntities = new List<TemporalEntity>();
    
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
}
