using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class MenuAudioManager : MonoBehaviour
{


    #region Components


    [Header("Components")]
    [SerializeField] private MainMenuManager mainMenuManager;
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource uISource;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip buttonHoverClip;
    [SerializeField] private AudioClip buttonClickClip;

    #endregion Components


    #region Methods


    #region Startup


    //-------------------------//
    void Start()
    //-------------------------//
    {
        Init();

    }//END Start

    //-------------------------//
    void Init()
    //-------------------------//
    {

        float masterVolume = PlayerPrefs.GetFloat("MasterAudio");
        float musicVolume = PlayerPrefs.GetFloat("MusicAudio");
        float sfxVolume = PlayerPrefs.GetFloat("SFXAudio");

        mainMixer.SetFloat("masterVolume", masterVolume);
        mainMixer.SetFloat("musicVolume", musicVolume);
        mainMixer.SetFloat("sfxVolume", sfxVolume);


        // foreach (Button _button in mainMenuManager.mainMenuButtons)
        // {
        //     _button.RegisterCallback<ClickEvent>(PlayButtonClick);
        //     _button.RegisterCallback<MouseEnterEvent>(PlayButtonHover);
        // } 

    }//END Init


    #endregion Startup


    #region SFX


    //-------------------------//
    public void PlayButtonHover()
    //-------------------------//
    {
        uISource.PlayOneShot(buttonHoverClip);

    }//END PlayButtonHover

    //-------------------------//
    public void PlayButtonClick()
    //-------------------------//
    {
        uISource.PlayOneShot(buttonClickClip);

    }//END PlayButtonClick


    #endregion SFX


    #endregion Methods



}//END AudioManager
