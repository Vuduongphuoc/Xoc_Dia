using UnityEngine;
using UnityEngine.UI;
public class CoinsSystem : MonoBehaviour
{
    public static CoinsSystem Instance;
    public Text moneyDisplay;
    public Text menuMoneyDisplay;

    public GameObject coin;
    public Sprite[] coinImg;

    SpriteRenderer coinPrefabImg;

    public static int moneyValue;
    public static int moneyPlayerget;
    public static int realmoneyPlayerGet;
    public static int betCoinsValue;
    public static int coinsId;
    public bool isSelected;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        moneyValue = 3000;  
    }
    void Start()
    {
        coinPrefabImg = coin.GetComponent<SpriteRenderer>();
        moneyDisplay.text = " $ " + moneyValue;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChoseCoinsValue(int id)
    {
        isSelected = !isSelected;
        
        if (id == 0)
        {
            coinPrefabImg.sprite = coinImg[0];
            betCoinsValue = 10;
            coinsId = id;
        }
        else if (id == 1)
        {
            coinPrefabImg.sprite = coinImg[1];
            betCoinsValue = 20;
            coinsId = id;
        }
        else if (id == 2)
        {
            coinPrefabImg.sprite = coinImg[2];
            betCoinsValue = 50;
            coinsId = id;
        }
        else if (id == 3)
        {
            coinPrefabImg.sprite = coinImg[3];
            betCoinsValue = 100;
            coinsId = id;
        }
        else if (id == 4)
        {
            coinPrefabImg.sprite = coinImg[4];
            betCoinsValue = 200;
            coinsId = id;
        }
        else if (id == 5)
        {
            coinPrefabImg.sprite = coinImg[5];
            betCoinsValue = 300;
            coinsId = id;
        }
    }
}
