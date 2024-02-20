using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{

    [SerializeField] private Button settingsButton;
    [SerializeField] private Button roomButton;
    [SerializeField] private Button resumeButton;

    public GameObject resumePanel;
    public bool pause = false;


    private void Start()
    {
        roomButton.onClick.AddListener(RoomButton);
        resumeButton.onClick.AddListener(ResumeButton);
        settingsButton.onClick.AddListener(SettingsButton);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //Pause();
            if(pause == false)
            {
                resumePanel.SetActive(true);
                pause = true;
                Time.timeScale = 0f;
            }else if(pause == true)
            {
                ResumeButton();
            }
        }
    }
    public void ResumeButton() //es escribir lo mismo pero totalmente lo contrario
    {
        resumePanel.SetActive(false);
        pause = false;
        Time.timeScale = 1f;
    }
  
    public void RoomButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM);
    }

    public void SettingsButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.SETTINGS);
    }

    
    
}
