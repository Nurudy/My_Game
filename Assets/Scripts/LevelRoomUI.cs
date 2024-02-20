using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelRoomUI : MonoBehaviour
{
    [SerializeField] private Button oneButton;
    //[SerializeField] private Button twoButton;
    //[SerializeField] private Button threeButton;

    private void Start()
    {
        oneButton.onClick.AddListener(OneButton);
    }

    public void OneButton()
    {
        ChangeScenes.Load(ChangeScenes.Scene.GAME);
    }
}
