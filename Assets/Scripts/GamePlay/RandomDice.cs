using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RandomDice : MonoBehaviour
{
    //dices
    public List<SpriteRenderer> dices;
    [SerializeField] private Sprite[] spr;

    //Odd and Even buttons value
    [Header("Odd & Even")]
    public List<GameObject> oddButtons;
    public List<GameObject> evenButtons;

    //MoneyDisplay on bet buttons
    [Header("Money")]
    public BetSystem betsystem;
    public Text moneyDisplay;
    public Text moneyPlayerget;

    //Bot
    //public Text[] moneyBotGet;
    //public GameObject[] money_Bot_Get_Display;

    public GameObject dishcover;
    public GameObject host;

    //CountDown and disable buttons
    [Header("CountDown")]
    float countdownTime;
    public GameObject startBetting;
    public GameObject endBetting;
    public GameObject countdownDisplay;
    public GameObject moneyPlayerGet;
    public GameObject[] btnDisable;

    public static RandomDice Instance;
    public bool inCountDown;
    public bool inBetting;


    //Shake the hecking dish

    [Header("Dish")]
    private float duration;
    private float strength;
    private int vibrato;
    private float randoms;
    public GameObject dish;

    private void Awake()
    {
        Instance = this;
      
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        duration = 2f;
        strength = 1f;
        randoms = Random.Range(2,10);
        vibrato = 5;

        betsystem.ResetResult();
        countdownDisplay.SetActive(false);
        StartCoroutine(TimeCountDown());
        //CheckColor();
        //dices = GameObject.FindGameObjectsWithTag("Dice");
    }

    // Cái này là data đã random nhá

    List<int> data = new List<int>();


    // Event chỉ call vào 1 method thôi, từ cái này call sang các method nhỏ khác

    // Method này bao gồm việc random data và set color cho dice
    // Cho thêm màu xanh đỏ tím vàng vào nó cũng ăn nhé

    void GenerateData()
    {
        data.Clear();
        dices.ForEach(x =>
        {
            var randomColor = Random.Range(0,spr.Length );
            data.Add(randomColor);
            x.sprite = spr[randomColor];    
        });
    }

    // Show kết quả

    public void Even()
    {
        // Chẵn
        if (data.Count(x => x == 0) % 2 == 0)
        {
            CoinsSystem.evenMoney += BetSystem.chanbetValue;
            evenButtons[0].GetComponent<ButtonDoSomething>().enabled = true;
            if (data.Count(x => x == 0) == 4)
            {
                
                evenButtons[1].GetComponent<ButtonDoSomething>().enabled = true;
                CoinsSystem.evenMoney += (BetSystem.allWhiteValue * 12);
            }
            if (data.Count(x => x == 1) == 4)
            {
                
                evenButtons[2].GetComponent<ButtonDoSomething>().enabled = true;
                CoinsSystem.evenMoney += (BetSystem.allRedValue * 12);    
            }           
        }
        else
        {
            CoinsSystem.evenMoney = 0;
            evenButtons[0].GetComponent<ButtonDontSomething>().enabled = true;
            evenButtons[1].GetComponent<ButtonDontSomething>().enabled = true;
            evenButtons[2].GetComponent<ButtonDontSomething>().enabled = true;
        }
    }
    //
    public void Odd()
    {
        //Lẻ
        if (data.Count(x => x == 0) % 2 != 0)
        {
            CoinsSystem.oddMoney += BetSystem.lebetValue;
            oddButtons[0].GetComponent<ButtonDoSomething>().enabled = true;
            if (data.Count(x => x == 0) == 3)
            {
                
                CoinsSystem.oddMoney += (BetSystem.whiteRedValue * 3);
                oddButtons[1].GetComponent<ButtonDoSomething>().enabled = true;
            }
            if (data.Count(x => x == 1) == 3)
            {
                
                CoinsSystem.oddMoney += (BetSystem.redWhiteValue * 3);
                oddButtons[2].GetComponent<ButtonDoSomething>().enabled = true;
            }
        }
        else
        {
            CoinsSystem.oddMoney = 0;
            oddButtons[0].GetComponent<ButtonDontSomething>().enabled = true;
            oddButtons[1].GetComponent<ButtonDontSomething>().enabled = true;
            oddButtons[2].GetComponent<ButtonDontSomething>().enabled = true;
        }
        
    }
    void CountMoney()
    {
        betsystem.ResetResult();
        if (betsystem.isBet)
        {
            CoinsSystem.moneyPlayerget = CoinsSystem.oddMoney + CoinsSystem.evenMoney;
            CoinsSystem.moneyValue = CoinsSystem.moneyValue + CoinsSystem.moneyPlayerget;
            PlayerPrefs.SetInt("money", CoinsSystem.moneyValue);
        }
       
    }

    // Getter này trả về true nếu chẵn
    
    IEnumerator Result()
   {
        //Gacha place
        GenerateData();

        dishcover.GetComponent<Animator>().Play("DishCoverOpen");
        yield return new WaitForSeconds(0.7f);

        Even();
        Odd();
        Debug.Log("Số dice có màu trắng là : " + data.Count(x => x == 0));
        Debug.Log("Số dice có màu đỏ là : " + data.Count(x => x == 1));
        
        //count money player get and show it on player balance
        CountMoney();
        yield return new WaitForSeconds(0.2f);
        moneyPlayerGet.SetActive(true);
        moneyPlayerget.text = " +" + CoinsSystem.moneyPlayerget;

        //This is money bot get after result
        //for (int i = 0 ; i < money_Bot_Get_Display.Length && i < moneyBotGet.Length; i++)
        //{

        //    money_Bot_Get_Display[i].SetActive(true);
        //    moneyBotGet[i].text = " + " + BotWork.instance.money_after_result;

        yield return new WaitForSeconds(1.3f);

        //    money_Bot_Get_Display[i].SetActive(false);
        //    BotWork.instance.botMoney.text = " $ " + BotWork.instance.money;
        //}

        moneyPlayerGet.SetActive(false);
        moneyDisplay.text = " $ " + CoinsSystem.moneyValue;
        //Ready for new round
        dishcover.GetComponent<Animator>().Play("DishCoverClose");
        inCountDown = false;
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < btnDisable.Length; i++)
        {
            btnDisable[i].GetComponent<Button>().enabled = true;
        }
        StartCoroutine(TimeCountDown());
    }
    public IEnumerator TimeCountDown()
    {
        //Start betting state
        startBetting.SetActive(true);
        host.SetActive(false);
        dish.SetActive(false);
        yield return new WaitForSeconds(1f);
        startBetting.SetActive(false);
        host.SetActive(true);
        dish.SetActive(true);


        //Time count downs
        inBetting = true;
        inCountDown = true;
        countdownTime = 10f;
        countdownDisplay.SetActive(true);
        while (countdownTime >= 0)
        {
            countdownDisplay.GetComponent<Text>().text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        inBetting = false;
        endBetting.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        dish.transform.DOShakePosition(duration, strength, vibrato, randoms);

        //End betting state
        for (int i = 0; i < btnDisable.Length; i++)
        {
            btnDisable[i].GetComponent<Button>().enabled = false;
        }
        countdownDisplay.SetActive(false);;
        host.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        endBetting.SetActive(false);
        host.SetActive(true);


        //Disable buttons before result
        StartCoroutine(Result());
    }
    
}             
 
