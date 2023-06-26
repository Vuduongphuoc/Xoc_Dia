
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BetSystem : MonoBehaviour
{
    public static BetSystem Instance;
    //Bets text
    public Text moneyDisplay;
    public Text chanBetDisplay;
    public Text leBetDisplay;
    public Text whiteRedDisplay;
    public Text redWhiteDisplay;
    public Text allWhiteDisplay;
    public Text allRedDisplay;

    //Coins
    public GameObject coinsparent;
    public Transform coinPosition;
    public Sprite[] clonecoinSprite;
    public int coinSpriteID;

    //Condiction
    public bool isBet;

    //Bets value
    public static int chanbetValue;
    public static int lebetValue;
    public static int whiteRedValue;
    public static int redWhiteValue;
    public static int allWhiteValue;
    public static int allRedValue;
    public static int playerBet;

    public static int allBetMoney;
    public static int btnid;

    private CoinsSystem[] coins;

    public List<GameObject> listCoin = new List<GameObject>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        isBet = false;
        coins = FindObjectsOfType<CoinsSystem>();
    }

    void CreateObject()
    {
        GameObject newcoin = ObjectPooling.instance.GetPooledObject();
        
        //Instantiate(coinsparent, coinsparent.transform.position, Quaternion.identity);
        if(newcoin != null)
        {
            newcoin.GetComponent<SpriteRenderer>().sprite = clonecoinSprite[coinSpriteID];
            newcoin.transform.position = coinPosition.position;
            newcoin.SetActive(true);
        }
        newcoin.GetComponent<BetCoin>().enabled = true;
        listCoin.Add(newcoin);

        if(CoinsSystem.moneyValue <= 0)
        {
            CoinsSystem.moneyValue = 3000;
            moneyDisplay.text = " $ " + CoinsSystem.moneyValue;
        }
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
                    playerBet += CoinsSystem.betCoinsValue;
                    isBet = true;
                    btnid = id;
                    CreateObject();

                }
                if (id == 1)
                {
                    playerBet += CoinsSystem.betCoinsValue;
                    isBet = true;
                    btnid = id;
                    CreateObject();

                }
                if (id == 2)
                {
                    playerBet += CoinsSystem.betCoinsValue;
                    isBet = true;
                    btnid = id;
                    CreateObject();
                }
                if (id == 3)
                {
                    playerBet += CoinsSystem.betCoinsValue;
                    isBet = true;
                    btnid = id;
                    CreateObject();
                }
                if (id == 4)
                {
                    playerBet += CoinsSystem.betCoinsValue;
                    isBet = true;
                    btnid = id;
                    CreateObject();
                }
                if (id == 5)
                {
                    playerBet += CoinsSystem.betCoinsValue;
                    isBet = true;
                    btnid = id;
                    CreateObject();
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
        CoinsSystem.moneyPlayerget = 0;

        chanBetDisplay.text = " $ 0 ";
        leBetDisplay.text = " $ 0 ";
        whiteRedDisplay.text = " $ 0";
        redWhiteDisplay.text = " $ 0";
        allWhiteDisplay.text = " $ 0";
        allRedDisplay.text = " $ 0 ";
    }

}
