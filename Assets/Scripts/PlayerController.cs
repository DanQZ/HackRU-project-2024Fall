using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Player playerRef;
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }
        if(Input.GetKey(KeyCode.A))
        {
            moveDirection -= Vector3.right;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDirection -= Vector3.up;
        }
        if(Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        moveDirection = moveDirection.normalized;
        float moveMagnitude =  playerRef.speed * Time.deltaTime;
        Vector3 moveVector = moveDirection * moveMagnitude;
        playerRef.transform.position += moveVector;
    }
}
