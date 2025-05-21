using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasicMenuManager : MonoBehaviour
{
    #region Components


    public enum MenuScreens : int
    {
        MAINMENU,
        SETTINGS,

    }


    [Header("Components")]
    [SerializeField] private GameObject[] menuScreens;


    #endregion Components


    //----------------------//
    public void ChangeScreenEnum(MenuScreens _newScreen)
    //----------------------//
    {
        int _currentScreen = (int)_newScreen;

        foreach (GameObject _screen in menuScreens)
        {
            if (_screen != menuScreens[_currentScreen])
            {
                _screen.SetActive(false);
            }
            _screen.SetActive(true);



        }
    }//END VOID ChangeScreen


    //----------------------//
    public void ChangeScreenInt(int _newScreen)
    //----------------------//
    {
        foreach (GameObject _screen in menuScreens)
        {
            if (_screen != menuScreens[_newScreen])
            {
                _screen.SetActive(false);
            }
            menuScreens[_newScreen].SetActive(true);

        }
    }//END VOID ChangeScreenInt


}//END CLASS 
