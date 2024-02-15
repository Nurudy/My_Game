using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; 
    private Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; //ponemos right porque así siempre irá hacia nuestra derecha, aunque hagamos un flip.
        Debug.Log("bum");
        Object.Destroy(this.gameObject, 1f);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.collider.gameObject.tag == "RAT")
         {
             collision.gameObject.GetComponent<Enemy>().TakeDamage(10);
            Destroy(gameObject);
        }
        else if (collision.collider.gameObject.tag == "WARM")
        {
            collision.gameObject.GetComponent<Enemy2>().TakeDamage(10);
            Destroy(gameObject);
        }
     }

    private void Awake()
    {
        
        //StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
     {
         yield return new WaitForSeconds(1);
         Object.Destroy(this.gameObject);
     }


}
