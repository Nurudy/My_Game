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
    public Animation animator;

    //[SerializeField] private LayerMask groundLayerMask; //está expuesta solo en el inspector. Es nuestro suelo.


    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  
    }


   

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
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
        }

        

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

           
        }
    }

   /* private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }*/




}
