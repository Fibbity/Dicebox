using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class coinflipManager : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private Button[] coinButtons;
    [SerializeField] private TMP_Text coinText;

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
            coinText.text = "HEADS";
        }
        else
        {
            coinText.text = "TAILS";

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
    IEnumerator IStartGame(bool _isStarting)
    //----------------------//
    {
        yield return new WaitForSeconds(3);

        if (_isStarting == true)
        {
            coinText.text = "You Go First";
        }
        else
        {
            coinText.text = "You Go Second";

        }

    }//END IStartGame



}//END CLASS coinflipManager
