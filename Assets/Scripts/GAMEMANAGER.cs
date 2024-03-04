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
            ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM);
            
            PlayerPrefs.SetInt("Level1Completed", 1); // "one" is completed.
            PlayerPrefs.Save();

            
        }
    }
    


}





