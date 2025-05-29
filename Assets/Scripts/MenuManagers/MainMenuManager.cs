using UnityEngine;
using UnityEngine.EventSystems; //Will be good for controller/arrow key support
using System.Collections.Generic;
using System;
using UnityEngine.UI; //Ol Reliable
// using UnityEngine.UIElements; //UIToolkit

public class MainMenuManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private QuitScreenManager quitScreenManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject settingsMenu;

    [SerializeField] private Button[] mainMenuButtons;

    #region Methods


    //-----------------------//
    private void Start()
    //-----------------------//
    {
        Init();

    }//END Start

    //-----------------------//
    private void Init()
    //-----------------------//
    {
        if (mainMenuButtons.Length == 0)
        {
            mainMenuButtons = mainMenu.GetComponentsInChildren<Button>();
        }

    }//END Init


    //-----------------------//
    public void ChangeScreen(int screenValue)
    //-----------------------//
    {
        if (screenValue == 0)
        {
            mainMenu.SetActive(false);
            gameMenu.SetActive(true);

        }
        else if (screenValue == 1)
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);

        }
    }//END ChangeScreen

    //-----------------------//
    public void QuitGame()
    //-----------------------//
    {
        foreach (Button _button in mainMenuButtons)
        {
            _button.enabled = false;
        }

        quitScreenManager.Quit();

    }//END QuitGame


    #endregion Methods


}//END MainMenuManager
