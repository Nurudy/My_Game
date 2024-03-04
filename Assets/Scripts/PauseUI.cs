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
    private bool pause = false; //with that line, the game won't start in pause

    

    


    private void Start()
    {

        resumePanel.SetActive(false);
        roomButton.onClick.AddListener(RoomButton);
        resumeButton.onClick.AddListener(ResumeButton);
        settingsButton.onClick.AddListener(SettingsButton);
   
    }
    private void Update() //if a press the esc button, it will appear my pause panel
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //Pause();
            if (pause == false)
            {
                resumePanel.SetActive(true);
                pause = true;
                Time.timeScale = 0f; //the "0" its to stop my time in game.
            }
            else if (pause == true)
            {
                ResumeButton();
            }
        }
    }
    public void ResumeButton() 
    {
        resumePanel.SetActive(false);
        pause = false;
        Time.timeScale = 1f; //the time scale helps me to continue the time.
    }

    public void RoomButton()
    {
        Time.timeScale = 1f;
        ChangeScenes.Load(ChangeScenes.Scene.LEVELROOM);
    }

    public void SettingsButton()
    {
        Time.timeScale = 1f;
        ChangeScenes.Load(ChangeScenes.Scene.MAINMENU);
    }

    

    

    }
