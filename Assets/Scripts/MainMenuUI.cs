using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuUI : MonoBehaviour
{ 
    //ALL MY BUTTONS
    [SerializeField] private Button roomButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        roomButton.onClick.AddListener(RoomButton);
        controlsButton.onClick.AddListener(ControlsButton);
        settingsButton.onClick.AddListener(SettingsButton);
        newGameButton.onClick.AddListener(NewGameButton);
        quitButton.onClick.AddListener(Application.Quit); //this one helps me to exit the game.
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

    public void NewGameButton() //the new game button makes a reset. It deletes all the data persistance and generate a new one.
    {
        ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM);

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        
    }


}
