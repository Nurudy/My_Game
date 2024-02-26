using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
   
    public float duration = 5f;

    private void Start()
    {
        Invoke("LoadNextScene", duration);
    }

    private void LoadNextScene()
    {
        ChangeScenes.Load(ChangeScenes.Scene.GAME);
    }
}
