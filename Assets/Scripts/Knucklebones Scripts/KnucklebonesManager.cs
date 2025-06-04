using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KnucklebonesManager : MonoBehaviour
{

    #region Components


    [Header("Components")]
    [Header("Dice")]
    [Tooltip("Ensure each image corresponds with its value, starting from 0")]
    [SerializeField] private Sprite[] dieImages;
    [SerializeField] private Image playerDieImage;
    [SerializeField] private Image aIDieImage;

    [SerializeField] private Image[] playerLeftColumnPlacements;
    [SerializeField] private Image[] playerCenterColumnPlacements;
    [SerializeField] private Image[] playerRightColumnPlacements;

    [SerializeField] private Image[] columnHighlightImages;

    [Header("Time")]
    [SerializeField] private float rollingFaceTime;
    [SerializeField] private float minimumRollTime;
    [SerializeField] private float maximumRollTime;
   
    private bool isRolling;
    private bool isPlayerTurn;
    private float rollTime;

    private Image selectedDie;


    #endregion Components

    #region Methods

    //----------------------//
    void Update()
    //----------------------//
    {
        if (isRolling == true)
        {
            DeductRollTime();
        }

    }//END Update

    //----------------------//
    void DeductRollTime()
    //----------------------//
    {
        rollTime -= Time.deltaTime;

    }//END DeductRollTime

    //1 need to set player or AI die
    //2 change the image at a rate we can see
    //3 needs to be clean
    //4 needs to stop on random number
    //5 die faces need to be random order and not repeat the last one
    //----------------------//
    public void RollDie(bool _isPlayerTurn) //Make private/initiate differently after testing
    //----------------------//
    {
        selectedDie = null;
        isPlayerTurn = _isPlayerTurn;

        rollTime = Random.Range(minimumRollTime, maximumRollTime);
        isRolling = true;

        StartCoroutine(IRollDice());


    }//END RollDie

    //----------------------//
    //0 = Left, 1 = Middle, 2 = Right
    public void HighlightColumn(int _column)
    //----------------------//
    {
        columnHighlightImages[_column].color = Color.blue;

        Image[] _currentColumnImages = new Image[3];

        switch (_column)
        {
            case 0:
                _currentColumnImages = playerLeftColumnPlacements;
                break;
            case 1:
                _currentColumnImages = playerCenterColumnPlacements;
                break;
            case 2:
                _currentColumnImages = playerRightColumnPlacements;
                break;
        }

        for (int i = 0; i < _currentColumnImages.Length; i++)
        {
            if (_currentColumnImages[i] == null)
            {
                _currentColumnImages[i].sprite = selectedDie.sprite;
                //playerLeftColumnPlacements[i].color.a = 0.75f;
            }
        }

    }//END HighlightColumn

    //----------------------//
    //0 = Left, 1 = Middle, 2 = Right
    public void SelectColumn(int _column)
    //----------------------//
    {
        


    }//END SelectColumn


    #endregion Methods


    //----------------------//
    //This is a recursive coroutine
    // Clean up later to ensure die faces don't repeat
    IEnumerator IRollDice()
    //----------------------//
    {
        int _currentFace = Random.Range(0, dieImages.Length);

        if (isPlayerTurn == true)
        {
            playerDieImage.sprite = dieImages[_currentFace];
        }
        else
        {
            aIDieImage.sprite = dieImages[_currentFace];
        }

        yield return new WaitForSeconds(rollingFaceTime);

        if (rollTime > 0)
        {
            StartCoroutine(IRollDice());
        }
        else
        {
            isRolling = false;
            selectedDie.sprite = dieImages[_currentFace];
        }

    }//END IRollDice



}//END CLASS KnucklebonesManager
