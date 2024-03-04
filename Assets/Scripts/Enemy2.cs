using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    private GameObject player;

    private int wormHealth = 30;
    private int currentWormHealth;

    private float timer;

    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioSource audioSource;
    private void Start() //the warm searh the player
    {
        player = GameObject.FindGameObjectWithTag("player");
        currentWormHealth = wormHealth;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 15) //"If the distance is less than X, the creature will start shooting bullets every second."
        {
            timer += Time.deltaTime;

            if (timer > 1.5f) //the worm shoot every 1.5 seconds
            {
                timer = 0;
                Shoot();
            }
        }

        void Shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
            audioSource.PlayOneShot(shootSound);
        }
    }

    public void TakeDamage(int damage) //as the rat enemy. The worm will destroy.
    {
        currentWormHealth -= damage;
        if (currentWormHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
