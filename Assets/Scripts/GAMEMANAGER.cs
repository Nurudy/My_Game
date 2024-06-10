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
                PlayerPrefs.SetInt("Level2Unlocked", 1); // Desbloquea el nivel 2
                ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM); // Cambia a la siguiente escena

            }
            else if (currentSceneName == "LEVEL2")
            {
                PlayerPrefs.SetInt("Level2Completed", 1); // Guarda que el nivel 2 está completado
                PlayerPrefs.SetInt("Level3Unlocked", 1); // Desbloquea el nivel 3
                ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM); // Cambia a la siguiente escena
            }
            else if (currentSceneName == "LEVEL3TRUE")
            {
                PlayerPrefs.SetInt("Level3Completed", 1); // Guarda que el nivel 3 está completado
                                                          // Aquí puedes realizar otras acciones si es necesario
                ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM); // Cambia a la siguiente escena
            }

            // Asegura que todos los cambios en PlayerPrefs se guarden
            PlayerPrefs.Save();


        }
    }

    //CHECKPOINTS

    public static GAMEMANAGER Instance { get; private set; }
    private Vector2 checkpointPos;

    private void Awake()
    {
        if (Instance == null)
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
        checkpointPos = newCheckpoint;
    }

    public Vector2 GetCheckpoint()
    {
        return checkpointPos;
    }



}





