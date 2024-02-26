using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAMEMANAGER : MonoBehaviour
{
    //respawn
    //escenas
    //objetos

    //PLAYER_MOV checkPointController;

    private static GAMEMANAGER instance;
    public Vector2 lastChekPoint;

    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
        //checkPointController = GameObject.FindGameObjectWithTag("player").GetComponent<PLAYER_MOV>(); //esto es para poder
        //acceder a la componente del gameobject del jugador. Asi el checkpoint lo reconoce(?
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            checkPointController.UpdateCheckpoint(transform.position);
        }
    }*/





}
