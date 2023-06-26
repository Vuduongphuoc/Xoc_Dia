
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject dish;
    public PauseBtn pause;
    public GameObject overLay;
    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public GameObject menuScene;
    public GameObject gamePlayUI;
    public GameObject gamePlay;
    public GameObject gameManager;
    
    public void toMenu()
    {
        DestroyObjects();
        overLay.SetActive(false);
        CoinsSystem.Instance.menuMoneyDisplay.text = " $ " + CoinsSystem.moneyValue;
        PlayerPrefs.SetInt("money", CoinsSystem.moneyValue);
        menuScene.SetActive(true);
        gamePlayUI.SetActive(false);
        gamePlay.SetActive(false);  
        gameManager.SetActive(false);
        pauseMenu.SetActive(false);
        CoinsSystem.Instance.isSelected = false;
    }
    public void toContinue()
    {
        if (pause.isPause)
        {
            PauseBtn.instance.gameObjectEnable();
            dish.SetActive(true);
            overLay.SetActive(false);
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
