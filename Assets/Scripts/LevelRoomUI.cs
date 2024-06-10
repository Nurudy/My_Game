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

    private void Start()
    {
        oneButton.onClick.AddListener(OneButton);
        level2.onClick.AddListener(TwoButton);
        level3.onClick.AddListener(ThreeButton);
        backButton.onClick.AddListener(BackButton);

        oneButton.interactable = true;

        // Cargar el progreso de los niveles usando PlayerPrefs
        bool level1Completed = PlayerPrefs.GetInt("Level1Completed", 0) == 1;
        Debug.Log("Level 1 Completed: " + level1Completed);
        level2.interactable = level1Completed; // El nivel 2 es interactivo solo si el nivel 1 está completado

        bool level2Unlocked = PlayerPrefs.GetInt("Level2Unlocked", 0) == 1;
        Debug.Log("Level 2 Unlocked: " + level2Unlocked);
        level3.interactable = level2Unlocked;
    }

    public void OneButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.LOADING); // Asegúrate de que esto cargue el nivel 1
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
        ChangeScenes.Load(ChangeScenes.Scene.LEVEL3TRUE);
    }

}
