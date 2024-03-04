using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   
    private float duration = 3.3f; //The time it takes for the scene to load.

    private void Start()
    {
        Invoke("LoadNextScene", duration); 
    }

    private void LoadNextScene()
    {
        ChangeScenes.Load(ChangeScenes.Scene.GAME);
    }
}
