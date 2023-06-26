using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMoney : MonoBehaviour
{
    public GameObject rewardPanel;
    
    public GameObject free_Claimable;
    public GameObject free_Not_Claimable;

    [Header("Free")]
    public Text freeMoney;
    public Text free_Amount_Display;
    bool FreeClaimable;

    [Header("ADS")]
    public Text AdsTxt;
    bool ADSClaimable;
    
    int free;
    int free_amount;
    // Start is called before the first frame update
    private void Awake()
    {
        free_amount = 3;
    }
    void Start()
    {
        free_amount = PlayerPrefs.GetInt("Free_amount");
        free = Random.Range(10000, 100000) / 10;
        FreeClaimable = true;
        ADSClaimable = true;
    }
    private void OnEnable()
    {
        freeMoney.text = " $ " + free;
        free_Amount_Display.text = " Your free chance available: " + free_amount + "/3"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        rewardPanel.SetActive(true);
    }
    public void Exit()
    {
        rewardPanel.SetActive(false);
    }
    public void Free()
    {
        if(free_amount > 0 && FreeClaimable)
        {
            free_amount--;
            PlayerPrefs.SetInt("Free_amount", free_amount);
            CoinsSystem.moneyValue += free;
            free = Random.Range(10000, 100000) / 10;
            freeMoney.text = " $ " + free;
        }
        
        else if( free_amount <= 0)
        {
            free_amount = 0;
            free_Amount_Display.color = Color.red;
            FreeClaimable =false;
            free_Claimable.SetActive(false);
            free_Not_Claimable.SetActive(true);
        }
    }
    public void Ads()
    {
        if (ADSClaimable)
        {
            AdsTxt.text = "Your reward videos is ready";
        }
    }
}
