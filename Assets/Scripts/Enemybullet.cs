using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class Enemybullet : MonoBehaviour
{
    [SerializeField] private GameObject player; //To detect the player's position.
    [SerializeField] private Rigidbody2D rb; //to detect the rigidbody and touch the player
    private float force = 24f;  
    private float timer;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
        Vector3 direction = player.transform.position - transform.position; //"This line will control the player's direction to follow it and calculate the distance."
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
        //By doing this, we don't limit the rotation of the bullet, so it follows the player constantly. It follows its rotation.

        transform.rotation = Quaternion.Euler(0, 0, rot); //"We use Euler because we've invoked 'Rad2Deg'.".
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<PLAYER_MOV>().TakeDamage(5);
            Destroy(gameObject);

        }
        
       
    }

    
    


}
