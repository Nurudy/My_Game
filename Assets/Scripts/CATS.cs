using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CATS : MonoBehaviour
{

    //Cat Follow
    [SerializeField] private Transform player;
    private float distanceFollow = 2f;
    private float speedFollow = 6f;
    private float catJump = 22f;
    private Rigidbody2D cat;
    [SerializeField] private LayerMask ground;
    
    //Animation
    private bool isJumping;
    private bool isWalking;
    [SerializeField] private Animator anim;
    
   
    private float horizontalInput;
    [SerializeField] private SpriteRenderer spriteRenderer;

    //CAT SPEECH
    [SerializeField] private Canvas[] speechCat;
    [SerializeField] private AudioSource audioSource; // Referencia al AudioSource que reproduce el maullido
    [SerializeField] private AudioClip[] mewing;
    private int currentSpeechIndex = 0;
    [SerializeField] private Button nextButton;





    private void Start() //the "Start", starts with the cat's speech. It activates the canvas.
    {

        anim = GetComponent<Animator>();
        cat = GetComponent<Rigidbody2D>();
        foreach (Canvas canvas in speechCat)
        {
            canvas.gameObject.SetActive(false);
        }
        nextButton.gameObject.SetActive(false); // Oculta el botón al inicio
        nextButton.onClick.AddListener(AdvanceDialogue); // Agrega la función de avanzar diálogo
        StartCoroutine(DelayFeedback());

    }

    private void Update()
    {
        Vector2 Direction = player.position - transform.position; //it calculates the space between the cat and the player.
        float distance = Vector2.Distance(transform.position, player.transform.position);
        horizontalInput = Input.GetAxis("Horizontal");

        isWalking = Mathf.Abs(horizontalInput) > 0.1f;  
        anim.SetBool("iswalking", isWalking);

        //the cat horizontal movement

        if (Direction.magnitude > distanceFollow )
        {
            transform.Translate(Direction.normalized * speedFollow * Time.deltaTime);
        }

        //the cat jumping
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            cat.velocity += Vector2.up * catJump;
            isJumping = true;
            
        }

        if(distance > 5f) //if the distance cat its more than 5, it will appears near to the player.
        {
            Respawn();
        }

        //CAT FLIP 
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }


    }

    

    void Respawn()
    {
        transform.position = player.position;
        cat.velocity = Vector2.zero;
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground")) //the cat has the same player jump's lines
        {
            isJumping = false;

        }
         
    }

    private IEnumerator DelayFeedback()
    {
        yield return new WaitForSeconds(0.6f); //it waits 0.6s before start
        ShowDialogue();
    }
    private void ShowDialogue()
    {
        if (currentSpeechIndex < speechCat.Length)
        {
            speechCat[currentSpeechIndex].gameObject.SetActive(true); // Activa el canvas actual

            if (currentSpeechIndex < mewing.Length && mewing[currentSpeechIndex] != null) // Hace que el gato suene al mismo tiempo
            {
                audioSource.PlayOneShot(mewing[currentSpeechIndex]);
            }

            nextButton.gameObject.SetActive(true); // enseña el botón de siguiente
        }
    }

    private void AdvanceDialogue()
    {
        if (currentSpeechIndex < speechCat.Length)
        {
            speechCat[currentSpeechIndex].gameObject.SetActive(false); // Desactiva el canvas actual
            nextButton.gameObject.SetActive(false); // Oculta el botón de siguiente
            currentSpeechIndex++;

            if (currentSpeechIndex < speechCat.Length)
            {
                ShowDialogue();
            }
        }
    }





}
