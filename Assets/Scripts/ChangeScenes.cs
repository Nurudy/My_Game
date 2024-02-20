using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
   


    public enum Scene
    {
        GAME,
        MAINMENU,
        CONTROLS,
        SETTINGS,
        LEVELROOM
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
