using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CATS : MonoBehaviour
{
  

    public Transform player;
    public float distanceFollow;
   public float distanceRespawn;
    public float speedFollow;
    public float catJump;
    public LayerMask ground;
    public bool isJumping;

   
   
   

    private Rigidbody2D cat;

    private void Start()
    {
        cat = GetComponent<Rigidbody2D>();
      
    }

    private void Update()
    {
        Vector2 Direction = player.position - transform.position;
        float distance = Vector2.Distance(transform.position, player.transform.position);


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
            Debug.Log("Gatosalto");
        }

        if(distance > 5f)
        {
            Respawn();
        }
        


    }

    void Respawn()
    {
        transform.position = player.position;
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

        }

    }

    
}
