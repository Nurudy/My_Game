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

    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            //Le hacemos daño al jugador
            PLAYER_MOV health = other.GetComponent<PLAYER_MOV>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    public void Start()
    {
        StartBucle();
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


}
