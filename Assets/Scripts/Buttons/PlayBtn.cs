
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    public ObjectPooling objPool;
    public GameObject gamescene;
    public GameObject ingame;
    public GameObject gameManager;
    public GameObject gameMenu;
    public GameObject pauseSetting;

    public void StartGame()
    {
        Time.timeScale = 1f;
        objPool.gameObject.SetActive(true);
        pauseSetting.SetActive(true);
        gamescene.SetActive(true);
        ingame.SetActive(true);
        gameManager.SetActive(true);
        gameMenu.SetActive(false);
        CoinsSystem.Instance.isSelected = false;
    }
}
