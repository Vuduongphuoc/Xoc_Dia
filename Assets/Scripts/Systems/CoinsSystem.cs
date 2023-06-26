using System;
using UnityEngine;
using UnityEngine.UI;
public class CoinsSystem : MonoBehaviour
{
    public static CoinsSystem Instance;
    public Text moneyDisplay;
    public Text menuMoneyDisplay;

    public GameObject coin;

    public static int moneyValue;
    public static int moneyPlayerget;
    public static int oddMoney;
    public static int evenMoney;
    public static int realmoneyPlayerGet;
    public static int betCoinsValue;
    public static int coinsId;
    public bool isSelected;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        moneyValue = PlayerPrefs.GetInt("money");
    }

    // Update is called once per frame
    void Update()
    {
        moneyDisplay.text = " $ " + moneyValue;
        menuMoneyDisplay.text = " $ " + moneyValue;
    }
    public void ChoseCoinsValue(int id)
    {
        
        isSelected = true;

        if (id == 0)
        {
            betCoinsValue = 10;
            coinsId = id;
            BetSystem.Instance.coinSpriteID = id;
        }
        else if (id == 1)
        {
            
            betCoinsValue = 20;
            coinsId = id;
            BetSystem.Instance.coinSpriteID = id;
        }
        else if (id == 2)
        {
            
            betCoinsValue = 50;
            coinsId = id;
            BetSystem.Instance.coinSpriteID = id;
        }
        else if (id == 3)
        {
            
            betCoinsValue = 100;
            coinsId = id;
            BetSystem.Instance.coinSpriteID = id;
        }
        else if (id == 4)
        {
            
            betCoinsValue = 200;
            coinsId = id;
            BetSystem.Instance.coinSpriteID = id;
        }
        else if (id == 5)
        {
            
            betCoinsValue = 300;
            coinsId = id;
            BetSystem.Instance.coinSpriteID = id;
        }
        
    }
}
