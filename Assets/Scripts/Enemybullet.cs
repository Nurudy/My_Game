using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    private GameObject player; //para detectar la posicion del jugador
    private Rigidbody2D rb; //y esto para que detecte su rigibody. Su toque(?
    public float force;
    private float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
        Vector3 direction = player.transform.position - transform.position; //esta linea controlara la direccion del jugador
        //para seguirla y calcular distancia.
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg; //de esta forma no limitamos la rotacion de la bala
        //y asi sigue al player constantemente. Que siga su rotacion
        transform.rotation = Quaternion.Euler(0, 0, rot); //utilizamos el Euler porque hemos llamado al "Rad2Deg".
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<PLAYER_MOV>().TakeDamage(20);
            Destroy(gameObject);

        }
    }
}
