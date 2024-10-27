using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    float timer = 0;
    protected float interval = 1.5f;

    protected Transform player => GameManager.instance.playerInstance.transform;

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (player == null) {
            return;
        }
        //Get the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        //Get the angle to the player
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        //Set the enemy's rotation to face the player
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        AttemptToShoot();
    }

    protected void AttemptToShoot () {
        //check if the time is greater than the interval
        if(Time.time > timer){
            //turn to face the player
            //transform.LookAt(Player.instance.transform);

            //shoot at the player
            ShootAtPlayer();
            //reset the timer
            timer = Time.time + interval;
        }
    }

    [SerializeField] GameObject bulletPrefab;
    protected void ShootAtPlayer () {
        //Create bullet object
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.transform.up = player.position - transform.position;
    }
}
