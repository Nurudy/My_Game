using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
   
    //THIS is my ChangeScenesManager, its like a brain

    public enum Scene
    {
        GAME,
        MAINMENU,
        CONTROLS,
        SETTINGS,
        LEVELROOM,
        LOADING,
        Video,
        LEVEL2,
        LEVEL3TRUE,
        CREDITS
    }

    public static void Load(Scene scene) //Because it's static, this function affects all scenes in order to load them.
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
