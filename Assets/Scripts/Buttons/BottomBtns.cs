
using UnityEngine;

public class BottomBtns : MonoBehaviour
{
    public GameObject luckyWheel;
    public GameObject dailyGift;
    public GameObject settingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Setting place
    public void OpenSetting()
    {
        settingPanel.SetActive(true);

    }
    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    //Lucky wheel spin
    public void Wheel()
    {
        luckyWheel.SetActive(true);
    }
    public void ExitWheel()
    {
        luckyWheel.SetActive(false);
    }

    //Daily Gift 
    public void DailyGift()
    {
        dailyGift.SetActive(true);
    }
    public void ExitDailyGift()
    {
        dailyGift.SetActive(false);
    }
}
