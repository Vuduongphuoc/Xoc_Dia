
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
                    CreateObject();
                    btnid = id;
                }
                if (id == 1)
                {
                    lebetValue += CoinsSystem.betCoinsValue;
                    leBetDisplay.text = " $ " + lebetValue;
                    CreateObject();
                    btnid = id;
                }
                if (id == 2)
                {
                    whiteRedValue += CoinsSystem.betCoinsValue;
                    whiteRedDisplay.text = " $ " + whiteRedValue;
                    CreateObject();

                    btnid = id;
                }
                if (id == 3)
                {
                    redWhiteValue += CoinsSystem.betCoinsValue;
                    redWhiteDisplay.text = " $ " + redWhiteValue;
                    CreateObject() ;
                    btnid = id;
                }
                if(id == 4)
                {
                    allWhiteValue += CoinsSystem.betCoinsValue;
                    allWhiteDisplay.text = " $ " + allWhiteValue;
                    CreateObject();
                    btnid = id;
                }
                if (id == 5)
                {
                    allRedValue += CoinsSystem.betCoinsValue;
                    allRedDisplay.text = " $ " + allRedValue;
                    CreateObject();
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
        CoinsSystem.moneyPlayerget = 0;

        chanBetDisplay.text = " $ 0 ";
        leBetDisplay.text = " $ 0 ";
        whiteRedDisplay.text = " $ 0";
        redWhiteDisplay.text = " $ 0";
        allWhiteDisplay.text = " $ 0";
        allRedDisplay.text = " $ 0 ";
    }

}
