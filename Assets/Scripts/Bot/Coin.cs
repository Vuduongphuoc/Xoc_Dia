using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public ButtonDoSomething btn;
    public ButtonDontSomething btned;

    public GameObject host;
    public GameObject bot;


    public Transform[] betPlace;
    Transform moveToBetPlace;

    float speed;
    public List<GameObject> listcoin = new List<GameObject>();
    void OnEnable()
    {
        moveToBetPlace = betPlace[Random.Range(0, 6)];
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 200f;
        moveToBetPlace = betPlace[Random.Range(0, 6)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!RandomDice.Instance.inBetting)
        {
            if (btn.isWin)
            {
                transform.position = Vector3.MoveTowards(transform.position, bot.transform.position, speed * Time.deltaTime);
                WinMoney();
            }
            else if (btned.isLose)
            {
                transform.position = Vector3.MoveTowards(transform.position, host.transform.position, speed * Time.deltaTime);
            }
            StartCoroutine(ResetPosition());
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToBetPlace.position, speed * Time.deltaTime);
            transform.parent = moveToBetPlace;
            listcoin.Add(gameObject);
            AddMoney();
            btn = GetComponentInParent<ButtonDoSomething>();
            btned = GetComponentInParent<ButtonDontSomething>();
        }
    }

    void WinMoney()
    {
        for(int i = 0; i < betPlace.Length; i++)
        {
            if (betPlace[0] || betPlace[1])
            {
                BotWork.instance.money_after_result = BotWork.instance.money + BotWork.instance.bettedmoney;
                BotWork.instance.botMoney.text = "$ " + BotWork.instance.money_after_result;
            }
            else if(betPlace[2] || betPlace[3])
            {
                BotWork.instance.money_after_result = (BotWork.instance.money + BotWork.instance.bettedmoney) *3;
                BotWork.instance.botMoney.text = "$ " + BotWork.instance.money_after_result;
            }
            else if (betPlace[4] || betPlace[5])
            {
                BotWork.instance.money_after_result = (BotWork.instance.money + BotWork.instance.bettedmoney) * 12;
                BotWork.instance.botMoney.text = "$ " + BotWork.instance.money_after_result;
            }
        }
    }
    void AddMoney()
    {
        for (int i = 0; i < betPlace.Length; i++)
        {
            if (BotWork.instance.inCoolDown)
            {
                if (transform.position == betPlace[0].position)
                {
                    BetSystem.chanbetValue = BotWork.instance.bettedmoney;
                }
                if (transform.position == betPlace[1].position)
                {
                    BetSystem.lebetValue = BotWork.instance.bettedmoney;
                }
                if (transform.position == betPlace[2].position)
                {
                    BetSystem.whiteRedValue = BotWork.instance.bettedmoney * 2;
                }
                if (transform.position == betPlace[3].position)
                {
                    BetSystem.redWhiteValue = BotWork.instance.bettedmoney * 3;
                }
                if (transform.position == betPlace[4].position)
                {
                    BetSystem.allWhiteValue = BotWork.instance.bettedmoney *6;
                }
                if (transform.position == betPlace[5].position)
                {
                    BetSystem.allRedValue = BotWork.instance.bettedmoney * 6;
                }
            }

        }
    }
    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(4f);
        for(int i =0; i< listcoin.Count; i++)
        {
            gameObject.SetActive(false);
            transform.parent = null;
            btn = null;
            btned = null;
            moveToBetPlace = null;
        }
    }
}
