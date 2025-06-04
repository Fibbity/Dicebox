using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;


public class coinflipManager : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private Button[] coinButtons;
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private KnucklebonesManager knuckleBonesManager;

    //----------------------//
    public void FlipCoin(int _side)
    //----------------------//
    {
        int _sideUp = Random.Range(0, 1);

        foreach (Button _button in coinButtons)
        {
            _button.enabled = false;
        }


        if (_sideUp == 0)
        {
            coinText.text = "Flipped HEADS";
        }
        else
        {
            coinText.text = "Flipped TAILS";

        }

        if (_side == _sideUp)
        {
            StartCoroutine(IStartGame(true));
        }
        else
        {
            StartCoroutine(IStartGame(false));
        }

    }//END FlipCoin

    //----------------------//
    IEnumerator IStartGame(bool _isPlayerTurn)
    //----------------------//
    {
        yield return new WaitForSeconds(2);

        if (_isPlayerTurn == true)
        {
            coinText.text = "You Go First";
        }
        else
        {
            coinText.text = "You Go Second";

        }

        yield return new WaitForSeconds(2);

        knuckleBonesManager.gameObject.SetActive(true);
        knuckleBonesManager.RollDie(_isPlayerTurn);
        this.gameObject.SetActive(false);

    }//END IStartGame



}//END CLASS coinflipManager
