using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsUI : MonoBehaviour
{
    [SerializeField] private Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(BackButton);
    }

    public void BackButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.MAINMENU);
    }
}
