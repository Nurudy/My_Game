using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_MOV : MonoBehaviour
{


    public float speed;
    private float Move;
    public float jumpHeight;
    private bool isJumping = false; 



    public Rigidbody2D rig;

    private void Start()
    {
        
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move = Input.GetAxis("Horizontal");
        

        rig.velocity = new Vector2(speed * Move, rig.velocity.y);
        
        if(Input.GetKeyDown(KeyCode.Escape) && !isJumping)
        {
            rig.AddForce(Vector2.up * jumpHeight); // you need a reference to the RigidBody2D component
            isJumping = true;
        }
    }
    /*private void OnCollisionEnter2D(Collision col)
    {
        if (col.gameObject.tag == "ground") // GameObject is a type, gameObject is the property
        {
            isJumping = false;
        }
    }*/


}
