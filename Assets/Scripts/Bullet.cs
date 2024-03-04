using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 25f;
    private Rigidbody2D rb;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; //this line could help with the flip of the player.
        
        Object.Destroy(this.gameObject, 0.7f);    
    }

    

    private void OnCollisionEnter2D(Collision2D collision) //in this function we order to the bullet make damage to both enemies.
     {
         if(collision.collider.gameObject.tag == "RAT")
         {
             collision.gameObject.GetComponent<Enemy>().TakeDamage(10);
            Destroy(gameObject);
        }
        else if (collision.collider.gameObject.tag == "WARM") //"SORRY; ITS WORM. I KNOW"
        {
            collision.gameObject.GetComponent<Enemy2>().TakeDamage(10);
            Destroy(gameObject);
        }
     }


}
