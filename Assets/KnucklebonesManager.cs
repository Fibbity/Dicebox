using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KnucklebonesManager : MonoBehaviour
{
    [Header("Components")]
    [Header("Dice")]
    [Tooltip("Ensure each image corresponds with its value, starting from 0")]
    [SerializeField] private Sprite[] dieImages;
    [SerializeField] private Image playerDieImage;
    [SerializeField] private Image aIDieImage;

    [Header("Time")]
    [SerializeField] private float rollingFaceTime;
    [SerializeField] private float minimumRollTime;
    [SerializeField] private float maximumRollTime;

    private bool isRolling;
    [SerializeField] private bool isPlayerTurn; //unserialize after testing
    private float rollTime;


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

    //----------------------//
    //Player 0 is the human, Player 1 is the AI
    //----------------------//
    public void DetermineDie(int _player)
    //----------------------//
    {



    }//END DetermineDie


    //1 need to set player or AI die
    //2 change the image at a rate we can see
    //3 needs to be clean
    //4 needs to stop on random number
    //5 die faces need to be random order and not repeat the last one
    //----------------------//
    public void RollDie() //Make private/initiate differently after testing
    //----------------------//
    {
        rollTime = Random.Range(minimumRollTime, maximumRollTime);
        isRolling = true;

        StartCoroutine(IRollDice());
        

    }//END RollDie

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

    }//END IRollDice


}//END CLASS KnucklebonesManager
