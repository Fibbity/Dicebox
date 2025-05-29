using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class QuitScreenManager : MonoBehaviour
{
    //[Header("Components")]

    //-----------------------//
    public void Quit()
    //-----------------------//
    {
    #if UNITY_EDITOR
        Debug.Log("Quit Game!");
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

    }//END Quit

} //END CLASS
