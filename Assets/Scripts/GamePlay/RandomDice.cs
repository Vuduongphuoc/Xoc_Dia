    using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomDice : MonoBehaviour
{

    public List<SpriteRenderer> dices;

    [SerializeField] private Color[] colors;

    // vcl, 3 cái kia còn éo phải cái nút.
    public List<SpriteRenderer> oddButtons;
    public List<SpriteRenderer> evenButtons;

    public BetSystem betsystem;
    public Text moneyDisplay;

    public GameObject dishcover;

    float countdownTime;
    public GameObject countdownDisplay;
    public GameObject[] btnDisable;

    public bool isWin;
    // Start is called before the first frame update
    void Start()
    {
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
            var randomColor = Random.Range(0, colors.Length);
            data.Add(randomColor);
            x.color = colors[randomColor];
        });
    }

    // Show kết quả

    public void Even()
    {
        // Chẵn
        if (data.Count(x => x == 0) % 2 == 0)
        {
            evenButtons[0].color = Color.green;
            CoinsSystem.moneyPlayerget += BetSystem.chanbetValue;
            isWin = true;
            if (data.Count(x => x == 0) == 4)
            {
                evenButtons[1].color = Color.green;
                CoinsSystem.moneyPlayerget += (BetSystem.allWhiteValue * 12);
                isWin = true;
            }
            else if(data.Count(x => x == 1) == 4)
            {
                evenButtons[2].color = Color.green;
                CoinsSystem.moneyPlayerget += (BetSystem.allRedValue * 12);
                isWin = true;
            } 
        }
        betsystem.ResetResult();
        //
    }
    public void Odd()
    {
        //Lẻ
        if (data.Count(x => x == 0) % 2 != 0)
        {
            oddButtons[0].color = Color.green;
            CoinsSystem.moneyPlayerget += BetSystem.lebetValue;
            isWin = true;
            if (data.Count(x => x == 0) == 3)
            {
                oddButtons[1].color = Color.green;
                CoinsSystem.moneyPlayerget += (BetSystem.whiteRedValue * 3);
                isWin = true;
            }
            else if (data.Count(x => x == 1) == 3)
            {
                oddButtons[1].color = Color.green;
                CoinsSystem.moneyPlayerget += (BetSystem.redWhiteValue * 3);
                isWin = true;
            }

        }
        betsystem.ResetResult();
    }


    // Getter này trả về true nếu chẵn

   IEnumerator Result()
   {
        //Gacha place
        GenerateData();

        dishcover.GetComponent<Animator>().Play("DishCoverOpen");
        yield return new WaitForSeconds(0.7f);

        Debug.Log("Số dice có màu trắng là : " + data.Count(x => x == 0));
        Debug.Log("Số dice có màu đỏ là : " + data.Count(x => x == 1));

        Even();
        Odd();
        yield return new WaitForSeconds(0.2f);
        //

        //count money player get and show it on player balance
        BetSystem.allBetMoney 
            = BetSystem.chanbetValue + BetSystem.lebetValue + BetSystem.whiteRedValue + BetSystem.redWhiteValue + BetSystem.allRedValue + BetSystem.allWhiteValue;
        CoinsSystem.realmoneyPlayerGet = CoinsSystem.moneyPlayerget - BetSystem.allBetMoney;
        yield return new WaitForSeconds(1f);
        moneyDisplay.text = " $ " + (CoinsSystem.moneyValue + CoinsSystem.realmoneyPlayerGet);
        //


        evenButtons.ForEach(x => x.color = Color.black);
        oddButtons.ForEach(x => x.color = Color.black);
        dishcover.GetComponent<Animator>().Play("DishCoverClose");

        yield return new WaitForSeconds(5f);

        //Active buttons after result
        for (int i = 0; i < btnDisable.Length; i++)
        {
            btnDisable[i].GetComponent<Button>().enabled = true;
        }   
        StartCoroutine(TimeCountDown());
    }
    IEnumerator TimeCountDown()
    {
        //Time count down
        countdownTime = 10f;
        countdownDisplay.SetActive(true);
        while (countdownTime >= 0)
        {
            countdownDisplay.GetComponent<Text>().text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        //Disable buttons before result
        for(int i = 0; i < btnDisable.Length; i++)
        {
            btnDisable[i].GetComponent<Button>().enabled = false;
        }
        //
        StartCoroutine(Result());
    }
}             
 
