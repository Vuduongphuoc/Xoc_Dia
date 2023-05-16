using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class BetSystem : MonoBehaviour
{
    //Bets text
    public Text moneyDisplay;
    public Text chanBetDisplay;
    public Text leBetDisplay;
    public Text whiteRedDisplay;
    public Text redWhiteDisplay;
    public Text allWhiteDisplay;
    public Text allRedDisplay;

    //Coins value
    public GameObject[] coinsparent;

    //Bets value
    public static int chanbetValue;
    public static int lebetValue;
    public static int whiteRedValue;
    public static int redWhiteValue;
    public static int allWhiteValue;
    public static int allRedValue;

    public static int allBetMoney;
    public static int btnid;

    private CoinsSystem[] coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = FindObjectsOfType<CoinsSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bet(int id)
    {

        //Get value from Bet buttons
        foreach(CoinsSystem c in coins)
        {
            if (c != null && c.isSelected)
            {
                CoinsSystem.moneyValue -= CoinsSystem.betCoinsValue;
                moneyDisplay.text = " $ " + CoinsSystem.moneyValue;
                if (id == 0)
                {
                    chanbetValue += CoinsSystem.betCoinsValue;
                    chanBetDisplay.text = " $ " + chanbetValue;
                    GameObject newcoin = 
                        Instantiate(coinsparent[CoinsSystem.coinsId], coinsparent[CoinsSystem.coinsId].transform.position, Quaternion.identity);
                    newcoin.GetComponent<BetCoin>().enabled = true;
                    
                    btnid = id;
                }
                if (id == 1)
                {
                    lebetValue += CoinsSystem.betCoinsValue;
                    leBetDisplay.text = " $ " + lebetValue;
                    GameObject newcoin = 
                        Instantiate(coinsparent[CoinsSystem.coinsId], coinsparent[CoinsSystem.coinsId].transform.position, Quaternion.identity);
                    newcoin.GetComponent<BetCoin>().enabled = true;
                    
                    btnid = id;
                }
                if (id == 2)
                {
                    whiteRedValue += CoinsSystem.betCoinsValue;
                    whiteRedDisplay.text = " $ " + whiteRedValue;
                    GameObject newcoin = 
                        Instantiate(coinsparent[CoinsSystem.coinsId], coinsparent[CoinsSystem.coinsId].transform.position, Quaternion.identity);
                    newcoin.GetComponent<BetCoin>().enabled = true;
                    

                    btnid = id;
                }
                if (id == 3)
                {
                    redWhiteValue += CoinsSystem.betCoinsValue;
                    redWhiteDisplay.text = " $ " + redWhiteValue;
                    GameObject newcoin = 
                        Instantiate(coinsparent[CoinsSystem.coinsId], coinsparent[CoinsSystem.coinsId].transform.position, Quaternion.identity);
                    newcoin.GetComponent<BetCoin>().enabled = true;
                    

                    btnid = id;
                }
                if(id == 4)
                {
                    allWhiteValue += CoinsSystem.betCoinsValue;
                    allWhiteDisplay.text = " $ " + allWhiteValue;
                    GameObject newcoin = 
                        Instantiate(coinsparent[CoinsSystem.coinsId], coinsparent[CoinsSystem.coinsId].transform.position, Quaternion.identity);
                    newcoin.GetComponent<BetCoin>().enabled = true;
                    

                    btnid = id;
                }
                if (id == 5)
                {
                    allRedValue += CoinsSystem.betCoinsValue;
                    allRedDisplay.text = " $ " + allRedValue;
                    GameObject newcoin = 
                        Instantiate(coinsparent[CoinsSystem.coinsId], coinsparent[CoinsSystem.coinsId].transform.position, Quaternion.identity);
                    newcoin.GetComponent<BetCoin>().enabled = true;
                    
                    btnid = id;
                }
            }
        }
    }
    public void ResetResult()
    {
        chanbetValue = 0;
        lebetValue = 0;
        whiteRedValue = 0;
        redWhiteValue = 0;
        allRedValue = 0;
        allWhiteValue = 0;

        chanBetDisplay.text = " $ 0 ";
        leBetDisplay.text = " $ 0 ";
        whiteRedDisplay.text = " $ 0";
        redWhiteDisplay.text = " $ 0";
        allWhiteDisplay.text = " $ 0";
        allRedDisplay.text = " $ 0 ";
    }
}
