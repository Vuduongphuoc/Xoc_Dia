
using UnityEngine;

public class PauseBtn : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pausebtn;
    public bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activePause()
    {
        isPause=true;
        if (isPause)
        {
            pausebtn.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
