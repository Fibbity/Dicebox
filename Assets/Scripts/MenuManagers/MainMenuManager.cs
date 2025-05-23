using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //Will be good for controller/arrow key support

public class MainMenuManager : MonoBehaviour
{
    [Header("Components")]
    //[SerializeField] private SettingsMenuManager settingsManager;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private QuitScreenManager quitScreenManager;

    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;


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
        playButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;

        quitScreenManager.StartQuit();

    }//END QuitGame
    

    #endregion Methods


}//END MainMenuManager
