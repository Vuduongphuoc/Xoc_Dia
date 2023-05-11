using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetCoin : MonoBehaviour
{
    private int CoinID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinsSystem.coinsId = CoinID;
        if(CoinID == 1)
        {
            
        }
    }

}
