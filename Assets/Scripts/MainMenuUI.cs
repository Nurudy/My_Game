using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button roomButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button settingsButton;

    private void Start()
    {
        roomButton.onClick.AddListener(RoomButton);
        controlsButton.onClick.AddListener(ControlsButton);
        settingsButton.onClick.AddListener(SettingsButton);
    }

    public void RoomButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM);
    }

   public void ControlsButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.CONTROLS);
    }

    public void SettingsButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.SETTINGS);
    }
}
