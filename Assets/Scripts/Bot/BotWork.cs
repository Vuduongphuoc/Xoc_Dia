using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BotWork : MonoBehaviour
{
    public static BotWork instance;
    public GameObject Bot;
    public GameObject coin;

    public Sprite[] imgs;
    public Sprite[] coinimgs;
    Sprite botspire;

    public Text botMoney;


    public bool inCoolDown;

    int coinimgID;
    public int money;
    public int bettedmoney;
    public int money_after_result;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        botspire = imgs[Random.Range(0, 9)];
        inCoolDown = false;
        Bot.GetComponent<SpriteRenderer>().sprite = botspire;
        coin.GetComponent<SpriteRenderer>().sprite = coinimgs[coinimgID];
        coinimgID = Random.Range(0, 6);
    }
    private void OnEnable()
    {
        botspire = imgs[Random.Range(0,9)];
        money = Random.Range(10000, 9999990) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (RandomDice.Instance.inBetting && !inCoolDown)
        {
            Bot.gameObject.SetActive(true);
            Betting();
        }
    }
    void Betting()
    {
        GameObject botcoin = ObjectPooling.instance.GetBotPooledObject();
        if (botcoin != null)
        {
            botcoin.GetComponent<SpriteRenderer>().sprite = coinimgs[coinimgID];
            botcoin.transform.position = coin.transform.position;
            botcoin.SetActive(true);
        }
        botcoin.GetComponent<Coin>().enabled = true;
        CoinValue();
    }
    void CoinValue()
    {
        if (coinimgID == 0)
        {
            money -= 10;
            bettedmoney += 10;
        }
        else if(coinimgID == 1)
        {
            money -= 20;
            bettedmoney += 20;
        }
        else if (coinimgID == 2)
        {
            money -= 50;
            bettedmoney += 50;
        }
        else if (coinimgID == 3)
        {
            money -= 100;
            bettedmoney += 100;
        }
        else if (coinimgID == 4)
        {
            money -= 200;
            bettedmoney += 200;
        }
        else if (coinimgID == 5)
        {
            money -= 300;
            bettedmoney += 300;
        }

        botMoney.text = "$" + money;

        if(money <= 0)
        {
            botMoney.text = "$ 0";
            Bot.gameObject.SetActive(false);
        }
        inCoolDown = true;
        StartCoroutine(CoolDown());
        
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.6f);
        coin.GetComponent<SpriteRenderer>().sprite = coinimgs[coinimgID];
        coinimgID = Random.Range(0, 6);
        inCoolDown = false;

    }
    
}
