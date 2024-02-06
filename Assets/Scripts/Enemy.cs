using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 7f;
    public float followTime = 3.0f;
    public float stopTime = 2.0f;
    private bool following = false;
    public PLAYER_MOV playerHealth; //esto es para añadir el script del jugador


    public int damage = 10;
    public int ratHealth = 30;
    public int currentRatHealth;

    public void Start()
    {
        StartBucle();
        currentRatHealth = ratHealth;
    }

    void StartBucle()
    {
        StartFollowing();
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
        //reiniciamos el bucle volviendo a iniciar el seguimiento.
        StartFollowing();
    }

    private void Update()
    {
        if (player != null && following)
        {
            Vector2 direction = player.position - transform.position;
            direction.y = 0; //de esta forma mantienen la misma altura

            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        currentRatHealth -= damage;
        if (currentRatHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            playerHealth.TakeDamage(damage);
        }
    }


}
