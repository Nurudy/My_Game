using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button backGameButton;

    private void Start()
    {
        backButton.onClick.AddListener(BackButton);
        backGameButton.onClick.AddListener(BackGameButton);
    }

    public void BackButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.MAINMENU);
    }

    public void BackGameButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.GAME);
    }
}
