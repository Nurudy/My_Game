using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    /*public void PlayGame()
    {
        SceneManager.LoadScene("GAME");
    }*/

    public enum Scene
    {
        GAME,
        MAINMENU,
        CONTROLS,
        SETTINGS
    }

    public void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
