using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExample : TemporalEntity
{
    float speed = 2f;

    Queue<Vector3> posQ = new Queue<Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }

    
}
