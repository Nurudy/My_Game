using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;

    public int warmHealth = 40;
    public int currentWarmHealth;

    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        currentWarmHealth = warmHealth;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 15) //si la distancia es menos que X, el bicho comenzara a disparar balas cada segundo
        {
            timer += Time.deltaTime;

            if (timer > 1.5f)
            {
                timer = 0;
                Shoot();
            }
        }

        void Shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        currentWarmHealth -= damage;
        if (currentWarmHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
