using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PLAYER_MOV : MonoBehaviour
{


    public float speed;
    private float Move;
    public float jump;
    public Rigidbody2D rig;
    public bool isGrounded;
    public bool isJumping;
    public Animator anim;

    public int maxHealth = 100;
    private int currentHealth; 

    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth; //empezamos el juego con la vida al maximo
    }

    private void Update()
    {
        Move = Input.GetAxis("Horizontal");


        rig.velocity = new Vector2(speed * Move, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rig.velocity += Vector2.up * jump;
            isJumping = true;
            Debug.Log("salto");
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Move == 0)
        {
            anim.SetBool("isWalking", false);
        } else
        {
            anim.SetBool("isWalking", true);
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //restamos el daño recibido a la salud actual

        Debug.Log("Healt:" + currentHealth);

        if (currentHealth <= 0) //verificamos si la salud ha llegado a cero o menos. (Jugador muerto)
        {
            Die();
        }
    }

    private void Die()
    {
        //podemos poner la logica de reiniciar el juego o llevarnos al menu pausa. Loquesea. O mas cosas, yoquese
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            
        }
        
    }

  




}
