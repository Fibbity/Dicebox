using UnityEngine;
using UnityEngine.EventSystems; //Will be good for controller/arrow key support
using System.Collections.Generic;
using System;
using UnityEngine.UI; //Ol Reliable
// using UnityEngine.UIElements; //UIToolkit

public class MainMenuManager : MonoBehaviour
{
    [Header("Components")]
    // [SerializeField] private UIDocument mainMenuUi;
    [SerializeField] private GameObject mainMenu; //Unnecessary? ^
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private QuitScreenManager quitScreenManager;

    [SerializeField] private Button[] mainMenuButtons;

    // public List<Button> buttons;


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
        // if (buttons.Count == 0)
        // {
        //     buttons = mainMenuUi.rootVisualElement.Query<Button>().ToList();
        // }

        //Can this be made into a switch or cleaner statement?
        //mainMenuUi.rootVisualElement.Q("PlayButton").RegisterCallback<OnButtonClick>(ChangeScreen(0))

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
        // foreach (Button _button in buttons)
        // {
        //     _button.SetEnabled(false);
        // }

        foreach (Button _button in mainMenuButtons)
        {
            _button.enabled = false;
        }

        quitScreenManager.StartQuit();

    }//END QuitGame


    #endregion Methods


}//END MainMenuManager
