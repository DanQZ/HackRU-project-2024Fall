using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player playerRef;
    // Update is called once per frame
    void Update()
    {
        Movement();
        Powers();
    }

    private void Movement(){
        Vector3 moveDirection = Vector3.zero;
        if(Input.GetKey(KeyCode.W)){
            moveDirection += Vector3.up;
        }
        if(Input.GetKey(KeyCode.A)){
            moveDirection -= Vector3.right;
        }
        if(Input.GetKey(KeyCode.S)){
            moveDirection -= Vector3.up;
        }
        if(Input.GetKey(KeyCode.D)){
            moveDirection += Vector3.right;
        }
        moveDirection = moveDirection.normalized;
        float moveMagnitude =  playerRef.speed * Time.deltaTime;
        Vector3 moveVector = moveDirection * moveMagnitude;
        playerRef.transform.position += moveVector;
    }

    private void Powers(){
        if(Input.GetKeyDown(KeyCode.Space)){
            AttemptReverseTime();
        }
    }

    private void AttemptReverseTime(){
        if(Time.time > TemporalEntityManager.nextAvailableTimeReverseTime){
            TemporalEntityManager.instance.ReverseTime();
        }
    }
}
