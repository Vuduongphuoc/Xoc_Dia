
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

    public int activeCount;

    void Start()
    {
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
                if (activeCount == 1)
                {
                    dailyReward.resetRewards();
                    activeCount++;
                    PlayerPrefs.GetInt("active", activeCount);
                    CoinsSystem.moneyValue = 3000;
                    PlayerPrefs.SetInt("MoneyValue", CoinsSystem.moneyValue);
                }
                loadingScreen.SetActive(false);
                menuScreen.SetActive(true);
                dailyObject.SetActive(true);
                loadingBarFill.fillAmount = 0;
            }
            return;
        }   
    }

}
