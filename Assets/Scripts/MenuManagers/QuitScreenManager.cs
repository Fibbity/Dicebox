using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class QuitScreenManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private float fillTime;
    [SerializeField] private float fillValue;
    [SerializeField] private Image quitImage;

    private Color imageColor;

    //-----------------------//
    public void StartQuit()
    //-----------------------//
    {
        imageColor = quitImage.color;

        StartCoroutine(QuitFade());

    }//END StartQuit

    //-----------------------//
    private void Quit()
    //-----------------------//
    {
    #if UNITY_EDITOR
        Debug.Log("Quit Game!");
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

    }//END Quit

    //Replace with a Lerp
    //-----------------------//
    private IEnumerator QuitFade()
    //-----------------------//
    {

        Debug.Log("Starting Fade");

        yield return new WaitForSeconds(fillTime);

        imageColor.a += fillValue;
        quitImage.color = imageColor;

        Debug.Log("Image Color: " + imageColor.a);


        if (imageColor.a >= 255)
        {
            Quit();
        }
        else
        {
            StartCoroutine(QuitFade());
        }

    }//END QuitFade
    

} //END CLASS
