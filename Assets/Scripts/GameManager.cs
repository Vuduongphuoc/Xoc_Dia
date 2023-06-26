using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        BetSystem.Instance.leBetDisplay.text = "$" + BetSystem.lebetValue;
        BetSystem.Instance.chanBetDisplay.text = "$" + BetSystem.chanbetValue ;
        BetSystem.Instance.redWhiteDisplay.text = "$" + BetSystem.redWhiteValue ;
        BetSystem.Instance.whiteRedDisplay.text = "$" + BetSystem.whiteRedValue ;
        BetSystem.Instance.allRedDisplay.text = "$" + BetSystem.allRedValue;
        BetSystem.Instance.allWhiteDisplay.text = "$" +BetSystem.allWhiteValue ;
    }
}
