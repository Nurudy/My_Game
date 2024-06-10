using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3UI : MonoBehaviour
{

    private void Update() //if a press the key "enter" I return to my main menu. Its like the final level.
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeScenes.Load(ChangeScenes.Scene.MAINMENU);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) //with this I put the logic for the "teletransport" stone. To go to the third level
    {
        if (collision.gameObject.CompareTag("player"))
        {
            ChangeScenes.Load(ChangeScenes.Scene.LEVEL3TRUE);     
        }
    }
}
