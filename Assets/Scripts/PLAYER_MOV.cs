using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PLAYER_MOV : MonoBehaviour
{


    public float speed;
    [SerializeField]private float horizontalInput;
    public float jump;
    public Rigidbody2D rig;
    public bool isGrounded;
    public bool isJumping;
    public bool isWalking;
    public Animator anim;
  
   
    

    public int maxHealth = 100;
    private int currentHealth;

    public Transform shootPoint;
    public GameObject bulletPrefab;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth; //empezamos el juego con la vida al maximo
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isWalking = horizontalInput != 0;

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rig.velocity += Vector2.up * jump;
            isJumping = true;
            Debug.Log("salto");
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        }
        
       
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(speed * horizontalInput, rig.velocity.y);
    }

    private void LateUpdate()
    {
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isWalking", isWalking);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //restamos el daño recibido a la salud actual

        Debug.Log("Healt:" + currentHealth);

        if (currentHealth <=0)
        {
            Destroy(gameObject);
        }

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

        Debug.Log(other.gameObject.name);

        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            
        }
        
    }

    




}
