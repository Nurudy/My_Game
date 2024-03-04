using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private float speed = 6f;
    private float followTime = 0.5f;
    private float stopTime = 0.4f;
    private bool following = false;
    private PLAYER_MOV playerHealth; //This is to access the player script


    private int damage = 10;
    private int ratHealth = 10;
    private int currentRatHealth;

    public void Start() //we start with the move bucle and the maxhealth
    {
        StartBucle();
        currentRatHealth = ratHealth;
    }

    void StartBucle()
    {
        StartFollowing(); //the rat followa the player
    }
    void StartFollowing()
    {
        following = true;

        Invoke("StopFollowing", followTime);
    }
    void StopFollowing()
    {
        following = false;
        Invoke("StartWaiting", stopTime);
    }
    void StartWaiting()
    {
        
        StartFollowing(); //We reset the loop by starting the tracking again.
    }

    private void Update()
    {
        if (player != null && following)
        {
            Vector2 direction = player.position - transform.position;
            direction.y = 0; //same height. PLayer = enemy

            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }

        
    }

    public void TakeDamage(int damage) //If the player loses all their life, the rat disappears.
    {
        currentRatHealth -= damage;
        if (currentRatHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //if the rat collisions with the player, it will make damage
    {
        if(collision.gameObject.tag == "player")
        {
            playerHealth.TakeDamage(damage);
        }
    }


}
