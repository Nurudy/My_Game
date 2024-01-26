using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CATS : MonoBehaviour
{
    /* [SerializeField] private GameObject player;
     [SerializeField] private float speed = 20f;
     public GameObject cat;
     private void Update()
     {
         Vector3 Playerpos = new Vector3(player.transform.position.x - 2f, player.transform.position.y,player.transform.position.z);
         transform.position = Vector2.MoveTowards(cat.transform.position, Playerpos, speed * Time.deltaTime);
     }*/

    public Transform player;
    public float distanceFollow;
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


    }

    /*void Jumping()
    {
        cat.velocity = new Vector2(cat.velocity.y, catJump * Time.deltaTime);
    }*/

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

        }

    }

    /*private bool ItsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, ground);
        return hit.collider != null;
    }*/
}
