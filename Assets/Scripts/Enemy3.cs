using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 targetPos;
    private PLAYER_MOV diePlayer;

    private void Start()
    {
        targetPos = posB.position;
        diePlayer = FindObjectOfType<PLAYER_MOV>();
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("player"))
        {
            
            diePlayer.Die();
        }
    }


}
