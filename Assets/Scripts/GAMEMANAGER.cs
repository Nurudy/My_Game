using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GAMEMANAGER : MonoBehaviour
{
    //respawn
    //escenas
    //objetos

    //PLAYER_MOV checkPointController;

    /*private static GAMEMANAGER instance;
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
        }*/

    //checkPointController = GameObject.FindGameObjectWithTag("player").GetComponent<PLAYER_MOV>(); //esto es para poder
    //acceder a la componente del gameobject del jugador. Asi el checkpoint lo reconoce(?


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            checkPointController.UpdateCheckpoint(transform.position);
        }
    }*/

    public VideoPlayer player;
    public Animation message;
    public float messageDelay = 2;
    private bool showMessage = false;



    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += OnVideoEnded;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeScenes.Load(ChangeScenes.Scene.LOADING);
        }

        if (!showMessage && player.time >= messageDelay)
        {
            message.Play();
            showMessage = true;
        }
    }

    private void OnVideoEnded(VideoPlayer player)
    {
        message.Stop();
        showMessage = true;

        ChangeScenes.Load(ChangeScenes.Scene.LOADING);
    }





    }





