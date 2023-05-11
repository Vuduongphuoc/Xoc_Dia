using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class BetSystem : MonoBehaviour
{
    public Text moneyDisplay;
    private CoinsSystem[] coins;
    public Text chanBetDisplay;
    public Text leBetDisplay;
    public Text whiteRedDisplay;
    public Text redWhiteDisplay;
    public Text allWhiteDisplay;
    public Text allRedDisplay;

    public GameObject[] coinsparent;

    public static int chanbetValue;
    public static int lebetValue;
    public static int whiteRedValue;
    public static int redWhiteValue;
    public static int allWhiteValue;
    public static int allRedValue;
    // Start is called before the first frame update
    void Start()
    {
        chanbetValue = 0;
        coins = FindObjectsOfType<CoinsSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bet(int id)
    {
        foreach(CoinsSystem c in coins)
        {
            if (c != null && c.isSelected)
            {
                CoinsSystem.moneyValue -= CoinsSystem.betCoinsValue;
                moneyDisplay.text = " $ " + CoinsSystem.moneyValue;
                if (id == 1)
                {
                    chanbetValue += CoinsSystem.betCoinsValue;
                    chanBetDisplay.text = " $ " + chanbetValue;
                    GameObject newcoins =  Instantiate(coinsparent[0], coinsparent[0].transform.position, Quaternion.identity);
                    newcoins.GetComponent<BetCoin>().enabled = true;
                }
                if (id == 2)
                {
                    lebetValue += CoinsSystem.betCoinsValue;
                    leBetDisplay.text = " $ " + lebetValue;
                    GameObject newcoins = Instantiate(coinsparent[1], coinsparent[1].transform.position, Quaternion.identity);
                    newcoins.GetComponent<BetCoin>().enabled = true;
                }
                if (id == 3)
                {
                    whiteRedValue += CoinsSystem.betCoinsValue;
                    whiteRedDisplay.text = " $ " + whiteRedValue;
                    GameObject newcoins = Instantiate(coinsparent[2], coinsparent[2].transform.position, Quaternion.identity);
                    newcoins.GetComponent<BetCoin>().enabled = true;
                }
                if (id == 4)
                {
                    redWhiteValue += CoinsSystem.betCoinsValue;
                    redWhiteDisplay.text = " $ " + redWhiteValue;
                    GameObject newcoins = Instantiate(coinsparent[3], coinsparent[3].transform.position, Quaternion.identity);
                    newcoins.GetComponent<BetCoin>().enabled = true;
                }
                if(id == 5)
                {
                    allWhiteValue += CoinsSystem.betCoinsValue;
                    allWhiteDisplay.text = " $ " + allWhiteValue;
                    GameObject newcoins = Instantiate(coinsparent[4], coinsparent[4].transform.position, Quaternion.identity);
                    newcoins.GetComponent<BetCoin>().enabled = true;
                }
                if (id == 6)
                {
                    allRedValue += CoinsSystem.betCoinsValue;
                    allRedDisplay.text = " $ " + allRedValue;
                    GameObject newcoins = Instantiate(coinsparent[5], coinsparent[5].transform.position, Quaternion.identity);
                    newcoins.GetComponent<BetCoin>().enabled = true;
                }
            }
        }
    }
    public void BetResult()
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
    public void CoinsRuntoBetPlace()
    {

    }
}
