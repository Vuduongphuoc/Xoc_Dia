
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    public GameObject gamescene;
    public GameObject ingame;
    public GameObject gameManager;
    public GameObject gameMenu;
    public GameObject pauseSetting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        pauseSetting.SetActive(true);
        gamescene.SetActive(true);
        ingame.SetActive(true);
        gameManager.SetActive(true);
        gameMenu.SetActive(false) ;
    }
}
