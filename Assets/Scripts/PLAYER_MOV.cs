using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PLAYER_MOV : MonoBehaviour
{

    //PLAYERMOVE
    private float speed = 8f;   
    [SerializeField]private float horizontalInput;
    private float jump = 22;
    [SerializeField] private Rigidbody2D rig;
    private Vector2 startPos = new Vector2(-8.75f, -6.85f);

    //ANIMATION
    public Animator anim;
    [SerializeField] private bool isGrounded;
    private bool isJumping;
    private bool isWalking;
    private bool firstTime = true;

    [SerializeField] private SpriteRenderer spriteRenderer;

    

    private float deathHight = -30f; //If the player falls these meters, they will die.


    [SerializeField]private AudioClip jumpSound;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI debugText; // Referencia al componente TextMeshProUGUI en el que mostrarás los mensajes de depuración


    //HEALTH AND DAMAGE

    private int maxHealth = 100;
    private int currentHealth;


    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ParticleSystem particleDeath;
    

    

    private void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        
        currentHealth = maxHealth; //we start with maxheatlh
        spriteRenderer = GetComponent<SpriteRenderer>();


    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isWalking = horizontalInput != 0; //if the player walks, the horizontalinput will be true


        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)//my player can jump.
        {
            
            rig.velocity += Vector2.up * jump;
            isJumping = true;
            audioSource.PlayOneShot(jumpSound);


        }

        if (Input.GetKeyDown(KeyCode.W)) //my player can shoot
        {
            Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            
            audioSource.PlayOneShot(shootSound);

        }

        if (firstTime && transform.position.y <= deathHight)
        {
            Die();
            firstTime = false; //this line helps me with the respawn. the bool start again with true.
        }

    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(speed * horizontalInput, rig.velocity.y);

        //PLAYER FLIP
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
       
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void LateUpdate()
    {
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isWalking", isWalking);
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //Subtracting damage


        Debug.Log("Healt:" + currentHealth);

        

        if (currentHealth <=0)
        {
            Die();

        }

       
    }

    private void Die()
    {
        
        StartCoroutine(Respawn(1f)); //wait one second before respawn
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


    void OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log(other.gameObject.name);

        if (other.gameObject.CompareTag("Ground")) //This function helps me avoid the double jump in the character.
        {
            isJumping = false;

        }

    }

    //SHOW THE CONSOLE HEALTH MESSAGES ON THE SCREEN

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog; // Subscribe the function HandleLog to the logMessageReceived event.
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog; // Unsubscribe... 
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        
        if (logString.Equals("Healt:" + currentHealth))
        {
            
            debugText.text = logString + "\n";//Update the TextMeshProUGUI component's text with the specific message.
            //The '\n' is like a line break to display the next message.

        }
    }



    

    




}
