using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_MOV : MonoBehaviour
{


    public float speed;
    private float Move;

    public Rigidbody2D rig;

    private void Start()
    {
        
    }

    private void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(speed * Move, rig.velocity.y);
    }



}
