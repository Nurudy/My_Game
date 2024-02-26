using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PLAYER_MOV : MonoBehaviour
{


    public float speed;    //PONER PRIVADAS LAS NO NECESARIAMENTE PÚBLICAS (PISTA: LA GRAN MAYORÍA =D ) 
    [SerializeField]private float horizontalInput;
    public float jump;
    public Rigidbody2D rig;
    public bool isGrounded;
    public bool isJumping;
    public bool isWalking;
    public Animator anim;
    private bool firstTime = true;

    public Vector2 startPos;

    public float deathHight = -70f; //si baja estos metros pupu morirá
    
    

    public int maxHealth = 100;
    private int currentHealth;

    public Transform shootPoint;
    public GameObject bulletPrefab;
    public ParticleSystem particleDeath;

    //private GAMEMANAGER gm;

    private void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GAMEMANAGER>();
        //transform.position = gm.lastChekPoint;
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

        if (firstTime && transform.position.y <= deathHight)
        {
            Die();
            firstTime = false;
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
            Die();

            Debug.Log("morido");
        }

       
    }

    private void Die()
    {
        //podemos poner la logica de reiniciar el juego o llevarnos al menu pausa. Loquesea. O mas cosas, yoquese
        StartCoroutine(Respawn(1f));
        particleDeath.Play();
     

    }

    
    
    IEnumerator Respawn(float duration)
    {

        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        currentHealth = maxHealth;
        firstTime = true;
        rig.velocity = Vector2.zero;


    }

    /*public void UpdateCheckpoint(Vector2 pos)
    {
        startPos = pos;
    }*/
    void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log(other.gameObject.name);

        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            
        }
        
    }

    




}
