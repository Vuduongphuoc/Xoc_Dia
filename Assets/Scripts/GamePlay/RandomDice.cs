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

    float countdownTime;
    public GameObject countdownDisplay;

    // Start is called before the first frame update
    void Start()
    {
        countdownDisplay.SetActive(false);
        //CheckColor();
        //dices = GameObject.FindGameObjectsWithTag("Dice");
    }

    // Cái này là data đã random nhá

    List<int> data = new List<int>();


    // Event chỉ call vào 1 method thôi, từ cái này call sang các method nhỏ khác
    public void OnClick()
    {
        StartCoroutine(TimeCountDown());
    }

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

    void ChangeBGEvenOrOdd()
    {
        
        //Lẻ
        if (data.Count(x => x == 0) % 2 != 0)
        {
            oddButtons[0].color = Color.green;
            oddButtons[1].color = Color.green;
            oddButtons[2].color = Color.green;
            CoinsSystem.moneyValue += BetSystem.lebetValue;
            if (data.Count(x => x == 0) == 3)
            {
                CoinsSystem.moneyValue += (BetSystem.whiteRedValue * 3);
            }
            else
            {
                oddButtons[1].color = Color.black;
            }
            if(data.Count(x => x == 1) == 3)
            {
                CoinsSystem.moneyValue += (BetSystem.redWhiteValue * 3);
            }
            else
            {
                oddButtons[2].color = Color.black;
            }
            moneyDisplay.text = " $ " + CoinsSystem.moneyValue;
        }

        // Chẵn
        if (data.Count(x => x == 0) % 2 == 0)
        {
            evenButtons[0].color = Color.green;
            CoinsSystem.moneyValue += BetSystem.chanbetValue;
            if (data.Count(x => x == 0) == 4)
            {
                evenButtons[1].color = Color.green;
                CoinsSystem.moneyValue += (BetSystem.allWhiteValue * 12);
            }
            else
            {
                evenButtons[1].color = Color.black;
            }

            if (data.Count(x => x == 1) == 4)
            {
                evenButtons[2].color = Color.green;
                CoinsSystem.moneyValue += (BetSystem.allRedValue * 12);
            }
            else
            {
                evenButtons[2].color = Color.black;
            }
            moneyDisplay.text = " $ " + CoinsSystem.moneyValue;
        }
        betsystem.BetResult();
        //
    }


    // Getter này trả về true nếu chẵn

   IEnumerator ResetAllState()
   {
        GenerateData();
        Debug.Log("Số dice có màu trắng là : " + data.Count(x => x == 0));
        Debug.Log("Số dice có màu đỏ là : " + data.Count(x => x == 1));
        ChangeBGEvenOrOdd();
        yield return new WaitForSeconds(3f);
        evenButtons.ForEach(x => x.color = Color.black);
        oddButtons.ForEach(x => x.color = Color.black);
   }
    IEnumerator TimeCountDown()
    {
        countdownTime = 10f;
        countdownDisplay.SetActive(true);
        while (countdownTime >= 0)
        {
            countdownDisplay.GetComponent<Text>().text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.SetActive(false);
        StartCoroutine(ResetAllState());
    }
}             
 
