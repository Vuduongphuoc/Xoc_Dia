using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyReward : MonoBehaviour
{
    public static DailyReward instance;

    public int lastDate;
    public int count;
    public int Day_1;
    public int Day_2;
    public int Day_3;
    public int Day_4;
    public int Day_5;
    public int Day_6;
    public int Day_7;

    public CoinsSystem money;

    public GameObject notification;

    public GameObject normal_1;
    public GameObject active_1;
    public GameObject claimed_1;

    public GameObject normal_2;
    public GameObject active_2;
    public GameObject claimed_2;

    public GameObject normal_3;
    public GameObject active_3;
    public GameObject claimed_3;

    public GameObject normal_4;
    public GameObject active_4;
    public GameObject claimed_4;

    public GameObject normal_5;
    public GameObject active_5;
    public GameObject claimed_5;

    public GameObject normal_6;
    public GameObject active_6;
    public GameObject claimed_6;

    public GameObject normal_7;
    public GameObject active_7;
    public GameObject claimed_7;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        count = PlayerPrefs.GetInt("count");
        Day_1 = PlayerPrefs.GetInt("Day_1");
        Day_2 = PlayerPrefs.GetInt("Day_2");
        Day_3 = PlayerPrefs.GetInt("Day_3");
        Day_4 = PlayerPrefs.GetInt("Day_4");
        Day_5 = PlayerPrefs.GetInt("Day_5");
        Day_6 = PlayerPrefs.GetInt("Day_6");
        Day_7 = PlayerPrefs.GetInt("Day_7");
        lastDate = PlayerPrefs.GetInt("LastDate");
        CoinsSystem.moneyValue = PlayerPrefs.GetInt("money");
        Reward();
        
        if (lastDate != System.DateTime.Now.Day)
        {
            
            if(Day_1 == 0)
            {
                Day_1 = 1;
            }
            else if (Day_2 == 0 )
            {
                Day_2 = 1;
            }
            else if (Day_3 == 0)
            {
                Day_3 = 1;
            }
            else if (Day_4 == 0 )
            {
                Day_4 = 1;
            }
            else if (Day_5 == 0)
            {
                Day_5 = 1;
            }
            else if (Day_6 == 0)
            {
                Day_6 = 1;
            }
            else if (Day_7 == 0)
            {
                Day_7 = 1;
            }
            else if(count == 7 && Day_7 == 2)
            {
                resetRewards();
            }
            Reward();
        }
    }

    public void Reward()
    {
        //Day 1
        if (Day_1 == 0)
        {
            normal_1.SetActive(true);
            active_1.SetActive(false);
            claimed_1.SetActive(false);
        }
        else if (Day_1 == 1)
        {
            normal_1.SetActive(false);
            active_1.SetActive(true);
            claimed_1.SetActive(false);
            notification.SetActive(true);
        }
        else if (Day_1 == 2)
        {
            normal_1.SetActive(false);
            active_1.SetActive(false);
            claimed_1.SetActive(true);
            notification.SetActive(false);
        }

        //Day 2
        if (Day_2 == 0)
        {
            normal_2.SetActive(true);
            active_2.SetActive(false);
            claimed_2.SetActive(false);
        }
        else if (Day_2 == 1)
        {
            normal_2.SetActive(false);
            active_2.SetActive(true);
            claimed_2.SetActive(false);
            notification.SetActive(true);
        }
        else if (Day_2 == 2)
        {
            normal_2.SetActive(false);
            active_2.SetActive(false);
            claimed_2.SetActive(true);
            notification.SetActive(false);
        }

        //Day 3
        if (Day_3 == 0)
        {
            normal_3.SetActive(true);
            active_3.SetActive(false);
            claimed_3.SetActive(false);
        }
        else if (Day_3 == 1)
        {
            normal_3.SetActive(false);
            active_3.SetActive(true);
            claimed_3.SetActive(false);
            notification.SetActive(true);
        }
        else if (Day_3 == 2)
        {
            normal_3.SetActive(false);
            active_3.SetActive(false);
            claimed_3.SetActive(true);
            notification.SetActive (false);
        }

        //Day 4
        if (Day_4 == 0)
        {
            normal_4.SetActive(true);
            active_4.SetActive(false);
            claimed_4.SetActive(false);
        }
        else if (Day_4 == 1)
        {
            normal_4.SetActive(false);
            active_4.SetActive(true);
            claimed_4.SetActive(false);
            notification.SetActive(true) ;
        }
        else if (Day_4 == 2)
        {
            normal_4.SetActive(false);
            active_4.SetActive(false);
            claimed_4.SetActive(true);
            notification .SetActive(false) ;
        }

        //Day 5
        if (Day_5 == 0)
        {
            normal_5.SetActive(true);
            active_5.SetActive(false);
            claimed_5.SetActive(false);
        }
        else if (Day_5 == 1)
        {
            normal_5.SetActive(false);
            active_5.SetActive(true);
            claimed_5.SetActive(false);
            notification.SetActive(true);
        }
        else if (Day_5 == 2)
        {
            normal_5.SetActive(false);
            active_5.SetActive(false);
            claimed_5.SetActive(true);
            notification.SetActive(false);
        }

        //Day 6
        if (Day_6 == 0)
        {
            normal_6.SetActive(true);
            active_6.SetActive(false);
            claimed_6.SetActive(false);
        }
        else if (Day_6 == 1)
        {
            normal_6.SetActive(false);
            active_6.SetActive(true);
            claimed_6.SetActive(false);
            notification.SetActive(true);
        }
        else if (Day_6 == 2)
        {
            normal_6.SetActive(false);
            active_6.SetActive(false);
            claimed_6.SetActive(true);
            notification.SetActive(false);
        }

        //Day 7
        if (Day_7 == 0)
        {
            normal_7.SetActive(true);
            active_7.SetActive(false);
            claimed_7.SetActive(false);
        }
        else if (Day_7 == 1)
        {
            normal_7.SetActive(false);
            active_7.SetActive(true);
            claimed_7.SetActive(false);
            notification.SetActive(true);
        }
        else if (Day_7 == 2)
        {
            normal_7.SetActive(false);
            active_7.SetActive(false);
            claimed_7.SetActive(true);
            notification.SetActive(false);
        }
    }

    public void GetReward_1()
    {
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + 500;
        Present.instance.reward = 500;
        updateMoneyAfterDaily();
        count = 1;
        PlayerPrefs.SetInt("count", count);

        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);

        Day_1 = 2;
        PlayerPrefs.SetInt("Day_1", 2);
        StartCoroutine(Present.instance.GiftGet());
        Reward();

    }

    public void GetReward_2()
    {
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + 1000;
        Present.instance.reward = 1000;
        updateMoneyAfterDaily();

        count = 2;
        PlayerPrefs.SetInt("count", count);
        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);

        Day_2 = 2;
        PlayerPrefs.SetInt("Day_2", 2);
        StartCoroutine(Present.instance.GiftGet());
        Reward();
    }

    public void GetReward_3()
    {
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + 2000;
        Present.instance.reward = 2000;
        updateMoneyAfterDaily() ;

        count = 3;
        PlayerPrefs.SetInt("count", count);
        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);


        Day_3 = 2;
        PlayerPrefs.SetInt("Day_3", 2);
        StartCoroutine(Present.instance.GiftGet());
        Reward();
    }

    public void GetReward_4()
    {
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + 2500;
        Present.instance.reward = 2500;
        updateMoneyAfterDaily();

        count = 4;
        PlayerPrefs.SetInt("count", count);
        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);

        Day_4 = 2;
        PlayerPrefs.SetInt("Day_4", 2);
        StartCoroutine(Present.instance.GiftGet());
        Reward();
    }

    public void GetReward_5()
    {
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + 5000;
        Present.instance.reward = 5000;
        updateMoneyAfterDaily();

        count = 5;
        PlayerPrefs.SetInt("count", count);
        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);

        Day_5 = 2;
        PlayerPrefs.SetInt("Day_5", 2);
        StartCoroutine(Present.instance.GiftGet());
        Reward();
    }

    public void GetReward_6()
    {
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + 8000;
        Present.instance.reward = 8000;
        updateMoneyAfterDaily();

        count = 6;
        PlayerPrefs.SetInt("count", count);
        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);

        Day_6 = 2;
        PlayerPrefs.SetInt("Day_6", 2);
        StartCoroutine(Present.instance.GiftGet());
        Reward();
    }

    public void GetReward_7()
    {
        CoinsSystem.moneyValue = CoinsSystem.moneyValue + 10000;
        Present.instance.reward = 10000;
        updateMoneyAfterDaily();
        
        count = 7;
        PlayerPrefs.SetInt("count", count);
        lastDate = System.DateTime.Now.Day;
        PlayerPrefs.SetInt("LastDate", lastDate);


        Day_7 = 2;
        PlayerPrefs.SetInt("Day_7", 2);
        StartCoroutine(Present.instance.GiftGet());
        Reward();
    }

    public void updateMoneyAfterDaily()
    {
        PlayerPrefs.SetInt("money", CoinsSystem.moneyValue);
        money.menuMoneyDisplay.text = " $ " + CoinsSystem.moneyValue;
    }

    public void resetRewards()
    { 
        Day_1 = 1;
        PlayerPrefs.SetInt("Day_1", 1);
        Day_2 = 0;
        PlayerPrefs.SetInt("Day_2", 0);
        Day_3 = 0;
        PlayerPrefs.SetInt("Day_3", 0);
        Day_4 = 0;
        PlayerPrefs.SetInt("Day_4", 0);
        Day_5 = 0;
        PlayerPrefs.SetInt("Day_5", 0);
        Day_6 = 0;
        PlayerPrefs.SetInt("Day_6", 0);
        Day_7 = 0;
        PlayerPrefs.SetInt("Day_7", 0);
        count = 0;
        PlayerPrefs.SetInt("count", 0);
    }


}
