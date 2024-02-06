using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1)
        {
            timer = 0;
            Shoot();
        }

        void Shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
}
