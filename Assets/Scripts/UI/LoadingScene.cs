
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{   
    public GameObject loadingScreen;
    public GameObject menuScreen;
    public GameObject dailyObject;
    public DailyReward dailyReward;
    public Image loadingBarFill;
    public bool isLoad;
    public CoinsSystem coinsystem;
    public int money;

    public int activeCount;

    private void Awake()
    {
        activeCount = 0;
    }

    void Start()
    {
        CoinsSystem.moneyValue = PlayerPrefs.GetInt("money");
        activeCount = PlayerPrefs.GetInt("active");
        loadingScreen.SetActive(true);
        isLoad = true;
    }
    void Update()
    {
        if (isLoad)
        {
            loadingBarFill.fillAmount += 0.2f * Time.deltaTime;
            if(loadingBarFill.fillAmount == 1)
            {
                isLoad = false;
                activeCount++;
                PlayerPrefs.SetInt("active", activeCount);
                loadingScreen.SetActive(false);
                menuScreen.SetActive(true);
                dailyObject.SetActive(true);
                loadingBarFill.fillAmount = 0;
                if (activeCount == 1)
                {
                    dailyReward.resetRewards();
                    CoinsSystem.moneyValue = 3000;
                    coinsystem.menuMoneyDisplay.text = " $ " + CoinsSystem.moneyValue;
                    PlayerPrefs.SetInt("money",CoinsSystem.moneyValue);
                }
                else if(activeCount >= 2)
                {
                    coinsystem.menuMoneyDisplay.text = " $ " + CoinsSystem.moneyValue;
                }
            }
            return;
        }   
    }

}
