
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public PauseBtn pause;
    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public GameObject menuScene;
    public GameObject gamePlayUI;
    public GameObject gamePlay;
    public GameObject gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toMenu()
    {
        DestroyObjects();
        CoinsSystem.Instance.menuMoneyDisplay.text = " $ " + CoinsSystem.moneyValue;
        menuScene.SetActive(true);
        gamePlayUI.SetActive(false);
        gamePlay.SetActive(false);  
        gameManager.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void toContinue()
    {
        if (pause.isPause)
        {
            pauseBtn.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    void DestroyObjects()
    {
        foreach(GameObject b in BetSystem.Instance.listCoin)
        {
            Destroy(b);
        }
        BetSystem.Instance.listCoin.Clear();
    }

}
