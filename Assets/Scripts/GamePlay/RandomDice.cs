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
    public List<GameObject> oddButtons;
    public List<GameObject> evenButtons;

    //MoneyDisplay on bet buttons
    public BetSystem betsystem;
    public Text moneyDisplay;

    public GameObject dishcover;

    //CountDown and disable buttons
    float countdownTime;
    public GameObject countdownDisplay;
    public GameObject[] btnDisable;

    public static RandomDice Instance;
    public bool inCountDown;


    
    //Shake the hecking dish
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
        CoinsSystem.moneyPlayerget = CoinsSystem.oddMoney + CoinsSystem.evenMoney;
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + CoinsSystem.moneyPlayerget;
        PlayerPrefs.SetInt("MoneyValue", CoinsSystem.moneyValue);
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

        CountMoney();
        yield return new WaitForSeconds(0.2f);
        //


        //count money player get and show it on player balance
        yield return new WaitForSeconds(0.9f);
        moneyDisplay.text = " $ " + CoinsSystem.moneyValue;
        dishcover.GetComponent<Animator>().Play("DishCoverClose");
        inCountDown = false;
        
        yield return new WaitForSeconds(6f);
        //Active buttons after result


        for (int i = 0; i < btnDisable.Length; i++)
        {
            btnDisable[i].GetComponent<Button>().enabled = true;
        }
        StartCoroutine(TimeCountDown());
    }
    public IEnumerator TimeCountDown()
    {

        inCountDown = true;
        //Time count downs
        countdownTime = 10f;
        countdownDisplay.SetActive(true);
        while (countdownTime >= 0)
        {
            countdownDisplay.GetComponent<Text>().text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        dish.transform.DOShakePosition(duration, strength, vibrato, randoms);

        countdownDisplay.SetActive(false);
        
        yield return new WaitForSeconds(0.5f);

        //Disable buttons before result

        for(int i = 0; i < btnDisable.Length; i++)
        {
            btnDisable[i].GetComponent<Button>().enabled = false;
        }
        //
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(Result());
    }
    
}             
 
