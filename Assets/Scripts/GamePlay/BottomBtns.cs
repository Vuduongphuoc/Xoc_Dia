
using UnityEngine;

public class BottomBtns : MonoBehaviour
{
    public GameObject luckyWheel;
    public GameObject dailyGift;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Wheel()
    {
        luckyWheel.SetActive(true);
    }
    public void ExitWheel()
    {
        luckyWheel.SetActive(false);
    }
    public void DailyGift()
    {
        dailyGift.SetActive(true);
    }
    public void ExitDailyGift()
    {
        dailyGift.SetActive(false);
    }
}
