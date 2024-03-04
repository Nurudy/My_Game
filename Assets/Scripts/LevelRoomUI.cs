using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelRoomUI : MonoBehaviour
{
    [SerializeField] private Button oneButton;
    [SerializeField] private Button level2;
    [SerializeField] private Button level3;
    [SerializeField] private Button backButton;

    public Button[] levelButtons;

    private void Start()
    {
        oneButton.onClick.AddListener(OneButton);
        level2.onClick.AddListener(TwoButton);
        level3.onClick.AddListener(ThreeButton);
        backButton.onClick.AddListener(BackButton);

        bool level1Completed = PlayerPrefs.GetInt("Level1Completed", 0) == 1;
        level2.interactable = level1Completed; //Level 2 is only interactable if level 1 is completed.

        bool level2Unlocked = PlayerPrefs.GetInt("Level2Unlocked", 0) == 1;
        level3.interactable = level2Unlocked; //Level 3 is only interactable if level 2 is completed.

    }



    public void OneButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.LOADING);
        
    }

    public void BackButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.MAINMENU);

    }

    public void TwoButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.LEVEL2);

    }

    public void ThreeButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.LEVEL3);

    }
}
