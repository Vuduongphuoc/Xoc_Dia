using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CoinsSystem : MonoBehaviour
{
    public Text moneyDisplay;
    public static int moneyValue;
    public static int betCoinsValue;
    public static int coinsId;
    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        coinsId = 0;
        moneyValue = 3000;
        moneyDisplay.text = " $ " + moneyValue;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChoseCoinsValue(int id)
    {
        isSelected = !isSelected;
        
            if (id == 1)
            {
                betCoinsValue = 10;
                coinsId = id;
            }
            else if (id == 2)
            {
                betCoinsValue = 20;
                coinsId = id;
            }
            else if (id == 3)
            {
                betCoinsValue = 30;
                coinsId = id;
            }
            else if (id == 4)
            {
                betCoinsValue = 50;
                coinsId = id;
            }
            else if (id == 5)
            {
                betCoinsValue = 100;
                coinsId = id;
            }
        }
    }
