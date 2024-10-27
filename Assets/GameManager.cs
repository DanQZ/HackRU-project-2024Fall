using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager instance;
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
        SpawnPlayer();
    }

    [SerializeField] GameObject playerPrefab;
    public GameObject playerInstance;


    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer(){
        if(playerInstance != null){
            Destroy(playerInstance);
        }
        playerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        // do somthing here
    }
}
