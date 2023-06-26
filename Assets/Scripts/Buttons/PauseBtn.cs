
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    public static PauseBtn instance;

    public GameObject dish;
    public GameObject overLay;
    public GameObject pauseMenu;
    public GameObject pausebtn;
    public bool isPause;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        isPause = false;
    }
    public void activePause()
    {
        isPause = true;
        if (isPause)
        {
            gameObjectDisable();
            dish.SetActive(false);
            overLay.SetActive(true);
            pausebtn.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void gameObjectDisable()
    {
        foreach (GameObject b in BetSystem.Instance.listCoin)
        {
            b.SetActive(false);
        }
    }
    public void gameObjectEnable()
    {
        foreach (GameObject b in BetSystem.Instance.listCoin)
        {
            b.SetActive(true);
        }
    }
}
