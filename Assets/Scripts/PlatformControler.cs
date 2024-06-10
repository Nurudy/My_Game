using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControler : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 targetPos;

    private void Start()
    {
        targetPos = posB.position;
    }



    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < .1f) targetPos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < .1f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //el exit es para abandonar el colisionador. Es decir, asi no lo dejas constantemente activo.
    {                                                  //solo se activa cuando el trigger con la etiqueta "player" lo toca, y desactiva cuando lo abandona.
        if (collision.CompareTag("player"))
        {
            collision.transform.SetParent(null);
        }
    }

}
