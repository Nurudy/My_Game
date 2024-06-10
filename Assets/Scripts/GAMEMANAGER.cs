using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GAMEMANAGER : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player")) //As the player progresses through levels, the progress is saved.
        {
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Verifica el nombre de la escena actual para determinar el nivel completado
            if (currentSceneName == "GAME")
            {
                PlayerPrefs.SetInt("Level1Completed", 1); // Guarda que el nivel 1 está completado
                PlayerPrefs.SetInt("Level2Unlocked", 1); // y desbloquea el nivel 2
                ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM); // Cambia a la siguiente escena directamente

            }
            else if (currentSceneName == "LEVEL2")
            {
                PlayerPrefs.SetInt("Level2Completed", 1);
                PlayerPrefs.SetInt("Level3Unlocked", 1); 
                ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM); 
            }
            else if (currentSceneName == "LEVEL3TRUE")
            {
                PlayerPrefs.SetInt("Level3Completed", 1); 
                                                          
                ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM); 
            }

            
            PlayerPrefs.Save(); //esto asegura el guardado


        }
    }

    //CHECKPOINTS

    public static GAMEMANAGER Instance { get; private set; }
    private Vector2 checkpointPos;

    private void Awake() //(he probado de hacer un singleton)
    {
        if (Instance == null) //asegura que el objeto no se destruya a no ser que cambie de escena o la empiece de nuevo.
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector2 newCheckpoint)
    {
        checkpointPos = newCheckpoint; //actuakliza el check
    }

    public Vector2 GetCheckpoint()
    {
        return checkpointPos;
    }



}





